using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ACS.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ACS.Core.Entities.Bases;
using System.Net.Http;
using Newtonsoft.Json;
using ACS.Web.Providers;
using System.Net.Http.Headers;

namespace ACS.Web.Areas.Identity.Pages.Account.Manage
{
    public class SubUsersModel : PageModel
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly UserManager<SubApplicationUser> _subUserManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SubUsersModel(UserManager<BaseUser> userManager
            , UserManager<SubApplicationUser> subUserManager
            , RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _subUserManager = subUserManager;
            _roleManager = roleManager;
        }
        public class SubUser
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
            public IEnumerable<string> Roles { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public List<SubUser> Users { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "رقم ملف المستخدم الفرعي")]
            public string SubUserFileNumber { get; set; }

            [Required]
            [Display(Name = "الرمز السري")]
            [StringLength(10, ErrorMessage = " {0} يجب أن لا يقل عن {2} رموز.", MinimumLength = 6)]
            public string Password { get; set; }
            public IEnumerable<string> Roles { get; set; }
        }

        private async Task LoadAsync(BaseUser user)
        {
            var SubUsers = _userManager.Users.Where(s => s is SubApplicationUser && s.EmailConfirmed == true).ToList().Cast<SubApplicationUser>().Where(t => t.UserName.Split(".").FirstOrDefault() == user.FileNumber).ToList();
            List<SubUser> list = new List<SubUser>();
            foreach (var Suser in SubUsers)
            {
                var subuser = new SubUser()
                {
                    Id = Suser.Id,
                    UserName = Suser.UserName,
                    Name = Suser.FullName,
                    Roles = await _subUserManager.GetRolesAsync(Suser)
                };
                list.Add(subuser);
            }
            Users = list.OrderByDescending(i =>i .UserName).ToList();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var Currentuser = await _userManager.GetUserAsync(User);
            if (Currentuser == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(Currentuser);
            return Page();
        }

        private int CheckSum(BaseUser user)
        {
            return _userManager.Users.Where(s => s is SubApplicationUser && s.EmailConfirmed == true).ToList().Cast<SubApplicationUser>().Where(t => t.UserName.Split(".").FirstOrDefault() == user.FileNumber).ToList().Count() + 1;
        }

        private class tempEmployee
        {
            [Key]
            public string EmpFileNo { get; set; }
            public string EmpName { get; set; }
            public string EmpPhone { get; set; }
            public string EmpEmail { get; set; }
            public string EmpResponsibilitycode { get; set; }
            public string PerRespCodeNoName { get; set; }
            public int JobCatId { get; set; }
            public string JobStatus { get; set; }
            public string RespCodeId { get; set; }
            public int DesignationId { get; set; }
            public string JobtypeName { get; set; }
        }

        private async Task<tempEmployee> GetEmployeeDataAsync(string fileNumber)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = PathsProvider.CERPS_API_URL
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = (await client.GetAsync(fileNumber)).Content.ReadAsStringAsync().Result;
            var employee = JsonConvert.DeserializeObject<tempEmployee>(result);
            return employee;
        }

        public async Task<IActionResult> OnPostNewSubUserAsync()
        {
            var Currentuser = await _userManager.GetUserAsync(User);
            var newSubUser = _userManager.Users.FirstOrDefault(e => e.FileNumber == Input.SubUserFileNumber);
            if (newSubUser == null)
            {
                var employeeTemp = await GetEmployeeDataAsync(Input.SubUserFileNumber);
                if (employeeTemp == null || employeeTemp.EmpFileNo ==null)
                {
                    StatusMessage = "رقم الموظف الذي أدخلته غير موجود بتقسيمك الإداري";
                    await LoadAsync(Currentuser);
                    return Page();
                }
                newSubUser = new SubApplicationUser
                {
                    FileNumber = employeeTemp.EmpFileNo
                    ,
                    PhoneNumber = employeeTemp.EmpPhone
                    ,
                    FullName = employeeTemp.EmpName
                    ,
                    ResponsibilityCode = employeeTemp.EmpResponsibilitycode
                    ,ArchiveUserPassword = Encode(Input.Password)
                };
            }
            if (newSubUser == null || newSubUser.ResponsibilityCode != Currentuser.ResponsibilityCode)
            // || newSubUser.ResponsibilityCode != Currentuser.ResponsibilityCode
            {
                StatusMessage = "رقم الموظف الذي أدخلته غير موجود بتقسيمك الإداري";
                await LoadAsync(Currentuser);
                return Page();
            }
            if (ModelState.IsValid)
            {
                var x = CheckSum(Currentuser);
                var NewSubUser = new SubApplicationUser
                {
                    UserName = Currentuser.FileNumber + $".{CheckSum(Currentuser)}",
                    Email = "subuser@acs.com",
                    FileNumber = newSubUser.FileNumber,
                    PhoneNumber = newSubUser.PhoneNumber,
                    EmailConfirmed = true,
                    ResponsibilityCode = Currentuser.ResponsibilityCode,
                    RespCodeId = Currentuser.RespCodeId,
                    FullName = newSubUser.FullName,
                    Department = Currentuser.Department,
                    MainUser = Currentuser as ApplicationUser,
                    JobtypeName = "  مستخدم فرعي - " + Currentuser.JobtypeName,
                    ArchiveUserPassword = Encode(Input.Password),
                    JobStatus="AE"
                };

                var result = await _subUserManager.CreateAsync(NewSubUser, Input.Password);
                if(Input.Roles != null)
                    await _subUserManager.AddToRolesAsync(NewSubUser, Input.Roles);

                if (!result.Succeeded)
                {
                    StatusMessage = "تمت إضافة المستخدم الفرعي بنجاح";
                }
            }
            await LoadAsync(Currentuser);
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteSubUser(string Id)
        {
            var Currentuser = await _userManager.GetUserAsync(User);
            var user = await _subUserManager.FindByIdAsync(Id);
            user.EmailConfirmed = false;
            user.UserName = user.Id;
            await _subUserManager.UpdateAsync(user);
            StatusMessage = "تم حذف المستخدم الفرعي بنجاح";
            await LoadAsync(Currentuser);
            return Page();
        }

        public async Task<IActionResult> OnGetResetPasswordOfSubUser(string Id)
        {
            var Currentuser = await _userManager.GetUserAsync(User);
            var user = await _subUserManager.FindByIdAsync(Id);
            await _subUserManager.RemovePasswordAsync(user);
            await _subUserManager.AddPasswordAsync(user, "123456");
            StatusMessage = "تمت إعادة تعيين كلمة المرور إلى الرمز 123456";
            await LoadAsync(Currentuser);
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateRolesOfSubUser(string Id, List<string> roles)
        {
            var Currentuser = await _userManager.GetUserAsync(User);
            var user = await _subUserManager.FindByIdAsync(Id);

            if (user != null)
            {
                var OldRoles = await _subUserManager.GetRolesAsync(user);
                if (OldRoles.Count > 0)
                {
                    await _subUserManager.RemoveFromRolesAsync(user, OldRoles);
                }
                if (roles.Count > 0)
                {
                    await _subUserManager.AddToRolesAsync(user, roles);
                }
            }

            StatusMessage = "تم تحديث صلاحيات المستخدم الفرعي";
            await LoadAsync(Currentuser);
            return Page();
        }

        public static string Encode(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }

        }
    }
}