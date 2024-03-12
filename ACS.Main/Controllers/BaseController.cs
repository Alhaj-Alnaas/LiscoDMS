using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.Web.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace ACS.Controllers
{
    [Authorize]
    public class BaseController<TUserType> : Controller where TUserType : BaseUser
    {
        private UserManager<BaseUser> _userManager;
        protected Task<BaseUser> GetUserAsync { get => _userManager.GetUserAsync(User); }
        protected TUserType _currentUser;
        public BaseController(UserManager<BaseUser> userManager)
        {
            _userManager = userManager;
        }

        protected async Task CheckAuthorization()
        {
            var user = await GetUserAsync;
            if (!(user is TUserType))
                await RedirectByUserType();
                //RedirectToAction("Error403", "Home");
            _currentUser = (user as TUserType);
        }
        protected async Task<IActionResult> RedirectByUserType()
        {
            var currentUser =  await GetUserAsync;
            if (currentUser is ApplicationUser)
            {
                return RedirectToAction("Inbox", "Messages");
            }
            else if (currentUser is SubApplicationUser)
            {
                return RedirectToAction("CreateDraft", "SubUsers");
            }
            else return NoContent();
        }
    }
}