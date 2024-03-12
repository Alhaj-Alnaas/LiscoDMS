using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading.Tasks;
using ACS.Core.Entities.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ACS.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<BaseUser> _userManager;

        public RegisterConfirmationModel(UserManager<BaseUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "أدخل رمز التحقق من الملكية")]
            [DataType(DataType.Text)]
            [Display(Name = "رمز التحقق من الملكية")]
            public string PhoneConfirmationCode { get; set; }
            public string FileNumber { get; set; }
        }

        public string FileNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }

        public IActionResult OnGetAsync(string fileNumber, string returnUrl = null)
        {
            if (fileNumber == null)
            {
                return RedirectToPage("/Index");
            }

            var user = _userManager.Users.FirstOrDefault(s => s.FileNumber == fileNumber);
            if (user == null)
            {
                return NotFound($"لا يوجد مستخدم برقم الملف  '{fileNumber}'.");
            }
            else
            {
                Email = user.Email;
                FileNumber = user.FileNumber;
                Name = user.FullName;
                Department = user.Department;
                Phone = user.PhoneNumber;

            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var user = _userManager.Users.FirstOrDefault(s => s.FileNumber == Input.FileNumber);
            if (user == null)
            {
                return NotFound($"لا يوجد مستخدم برقم الملف  '{FileNumber}'.");
            }
            
            if (user.PhoneConfirmationCode == Input.PhoneConfirmationCode)
            {
                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = true;
                await _userManager.UpdateAsync(user);
                return LocalRedirect(returnUrl);
            }
            else
            {
                return NotFound("الرمز الذي أدخلته خاطئ!");
            }
        }
    }
}
