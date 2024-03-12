
using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.Core.Interfaces.Providers;
using ACS.Core.Interfaces.Services;
using ACS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ACS.Web.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly UserManager<SubApplicationUser> _subUserManager;
        //private readonly IOrgnaizationServices<Organization> _orgServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserProvider(
              UserManager<BaseUser> userManager
            , UserManager<SubApplicationUser> subUserManager
            // ,IOrgnaizationServices<Organization> orgServices
            , IHttpContextAccessor httpContextAccessor
            )
        {
            _userManager = userManager;
            _subUserManager = subUserManager;
            //_orgServices = orgServices;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<string>> GetUserRolesAsync(BaseUser user)
        {
            return (await _userManager.GetRolesAsync(user)).ToList();
        }
        public string GetCurrentUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (!httpContext.User.Identity.IsAuthenticated)
                return null;
            return _userManager.GetUserId(httpContext.User);
        }
        public async Task<BaseUser> GetCurrentUserAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (!httpContext.User.Identity.IsAuthenticated)
                return null;
            return await _userManager.GetUserAsync(httpContext.User);
        }
        public List<BaseUser> GetAllUsers(BaseUser CurrentUser)
        {
            return _userManager.Users.Where(c => c.Id != CurrentUser.Id && c.JobStatus == "AE" && c.EmailConfirmed == true  && c is ApplicationUser).OrderBy(o => o.FullName).ToList();
            //&& c.ResponsibilityCode != "40000"
        }
        public List<BaseUser> GetRelatedUsers(int designationId, string CurrRespCode)
        {
            if (CurrRespCode.Substring(0, 2) == "43")
            {
                return _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId == 1 && x.ResponsibilityCode.Substring(0, 1) == "4").OrderBy(o => o.ResponsibilityCode).ToList();
            }

            else if (designationId==6 && CurrRespCode.Substring(2, 1) == "0")
            {
                return _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId == 1 && (
                                               // your section
                                               (x.ResponsibilityCode.Trim().Substring(0, 4) == CurrRespCode.Trim().Substring(0, 4)) ||
                                                // sections without department
                                                (x.ResponsibilityCode.Substring(3, 1) == "0" && x.ResponsibilityCode.Substring(4, 1) != "0") ||
                                                //all departments
                                                (x.ResponsibilityCode.Substring(3, 1) != "0" && x.ResponsibilityCode.Substring(4, 1) == "0") ||
                                                // your general department
                                                (x.ResponsibilityCode.Substring(0, 3) ==
                                                CurrRespCode.Substring(0, 3) && x.ResponsibilityCode.Substring(3, 1) == "0") ||

                                                //general departments
                                                (x.DesignationId == 5))
                                             ).OrderBy(o => o.ResponsibilityCode).ToList();
            }

            else if (designationId == 8 && CurrRespCode.Substring(3, 1) == "0")
            {
                return _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId == 1 && (
                                               // your department
                                               (x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3)) ||
                                                // all sections
                                                (x.ResponsibilityCode.Substring(4, 1) != "0") ||
                                                  // adv section
                                                  (x.ResponsibilityCode == "43040") ||
                                                //general departments
                                                (x.DesignationId==6))

                                             ).OrderBy(o => o.ResponsibilityCode).ToList();
            }

            else 
            {
                return designationId switch
                {
                    // Director Cases
                    4 => _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId == 1 && (
                                               // your departmen without general departmen
                                               (x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3) && x.ResponsibilityCode.Substring(4, 1) == "0") ||
                                                  //your general department
                                                  (x.ResponsibilityCode.Substring(0, 2) == CurrRespCode.Substring(0, 2) && x.ResponsibilityCode.Substring(3, 2) == "00") ||
                                                  // directors and chairman offices
                                                  (x.ResponsibilityCode.Substring(0, 2) == "43" && x.ResponsibilityCode.Substring(4, 1) == "0") ||
                                                (x.ResponsibilityCode.Substring(2, 3) == "000"))
                                                ).OrderBy(o => o.ResponsibilityCode).ToList(),

                    //general maneger Cases
                    5 => _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId == 1 && (
                                              //Your Departments
                                              (x.ResponsibilityCode.Substring(4, 1) == "0" && x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3)) ||
                                              // your sections  without  departments
                                              (x.ResponsibilityCode.Substring(3, 1) == "0" && x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3)) ||
                                              // departments without general department
                                              (x.ResponsibilityCode.Substring(2, 1) == "0" && x.ResponsibilityCode.Substring(4, 1) == "0" && x.ResponsibilityCode.Substring(3, 1) != "0") ||
                                              //All general departments
                                              (x.ResponsibilityCode.Substring(2, 1) != "0" && x.ResponsibilityCode.Substring(3, 2) == "00") ||
                                                  // your director
                                                  (x.ResponsibilityCode.Substring(0, 2) == CurrRespCode.Substring(0, 2) && x.ResponsibilityCode.Substring(2, 3) == "000") ||
                                                  // directors and chairman offices
                                                  (x.ResponsibilityCode.Substring(0, 2) == "43" && x.ResponsibilityCode.Substring(2, 3) != "000" && x.ResponsibilityCode.Substring(4, 1) == "0"))
                                                ).OrderBy(o => o.ResponsibilityCode).ToList(),

                    // maneger cases
                    6 => _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId == 1 && (
                                               // your section
                                               (x.ResponsibilityCode.Trim().Substring(0, 4) == CurrRespCode.Trim().Substring(0, 4)) ||
                                                // sections without department
                                                (x.ResponsibilityCode.Substring(3, 1) == "0" && x.ResponsibilityCode.Substring(4, 1) != "0") ||
                                                //all departments
                                                (x.ResponsibilityCode.Substring(3, 1) != "0" && x.ResponsibilityCode.Substring(4, 1) == "0") ||
                                                // your general department
                                                (x.ResponsibilityCode.Substring(0, 3) ==
                                                CurrRespCode.Substring(0, 3) && x.ResponsibilityCode.Substring(3, 1) == "0")) 

                                             ).OrderBy(o => o.ResponsibilityCode).ToList(),

                    // Head of section cases
                    8 => _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId == 1 && (
                                               // your department
                                               (x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3)) ||
                                                // all sections
                                                (x.ResponsibilityCode.Substring(4, 1) != "0") ||
                                                  // adv section
                                                  (x.ResponsibilityCode == "43040"))
                                             ).OrderBy(o => o.ResponsibilityCode).ToList(),


                    _ => _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId == 1 && x.ResponsibilityCode.Substring(0, 1) == "4").OrderBy(o => o.ResponsibilityCode).ToList(),
                };
            }
        }
        public BaseUser GetUserById(string Id)
        {
            return _userManager.Users.Where(x => x.Id == Id).FirstOrDefault();
        }
        public BaseUser GetUserByFileNumber(string FileNumber)
        {
            return _userManager.Users.Where(x => x is ApplicationUser && x.FileNumber == FileNumber).FirstOrDefault();
        }
        public BaseUser GetUserBySubUserFileNumber(string FileNumber)
        {
            var MainUserId = (_userManager.Users.FirstOrDefault(x => x is SubApplicationUser && x.FileNumber == FileNumber) as SubApplicationUser).MainUserId;
            return _userManager.Users.FirstOrDefault(x => x is ApplicationUser && x.Id == MainUserId);
        }
        public BaseUser GetUsersById(string UserId)
        {
            return _userManager.Users.Where(x =>
                   (x.Id.ToString() == UserId)).FirstOrDefault();
        }
        public List<BaseUser> GetLowLevelUsers(int designationId, string CurrRespCode)
        {
            if (CurrRespCode.Substring(0, 2) == "43")
            {
                return _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId == 1 &&
                        (x.ResponsibilityCode.Substring(2, 3) == "000")
                           ).ToList();
            }
            else
            {
                switch (designationId)
                {
                    case 4:// Director Cases
                        return _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId==1 && (
                         // your departmen without general departmen
                         (x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3) && x.ResponsibilityCode.Substring(4, 1) == "0") ||
                            //your general department
                            (x.ResponsibilityCode.Substring(0, 2) == CurrRespCode.Substring(0, 2) && x.ResponsibilityCode.Substring(3, 2) == "00"))).ToList();

                    case 5: //general maneger Cases
                        return _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId == 1 && (
                        //Your Departments
                        (x.ResponsibilityCode.Substring(4, 1) == "0" && x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3)) ||
                        // your sections  without  departments
                        (x.ResponsibilityCode.Substring(3, 1) == "0" && x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3)))).ToList();

                    case 6: // maneger cases
                        return _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId == 1 && (
                         (x.ResponsibilityCode.Substring(0, 4) == CurrRespCode.Substring(0, 4))
                            )).ToList();

                    case 8:// Head of section cases
                        return _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && (
                        (x.ResponsibilityCode.Substring(0, 5) == CurrRespCode.Substring(0, 5))
                           )).ToList();

                    default:
                        return _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && (
                        (x.ResponsibilityCode.Substring(0, 5) == CurrRespCode.Substring(0, 5))
                           )).ToList();
                }
            }
        }
        public List<BaseUser> GetAllLeaders(BaseUser CurrentUser)
        {
            return _userManager.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.JobCatId == 1 && x.Id != CurrentUser.Id).ToList();
        }
        public BaseUser GetUserByResponsibilityCode(string ResponsibilityCode, int designationId)
        {
            return _userManager.Users.Where(x => x is ApplicationUser && x.ResponsibilityCode == ResponsibilityCode && x.DesignationId == designationId).FirstOrDefault();
        }
    }
}
