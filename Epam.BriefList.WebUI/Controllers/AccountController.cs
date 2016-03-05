using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.WebUI.Filters;
using Epam.BriefList.WebUI.Mapping;
using Epam.BriefList.WebUI.Models;
using Microsoft.Owin.Security;

namespace Epam.BriefList.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        public AccountController(IUserProfileService userProfileService)
        {
            this._userProfileService = userProfileService;
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
        private ClaimsPrincipal Identity => (ClaimsPrincipal)Thread.CurrentPrincipal;


        [ChildActionOnly]
        public ActionResult Nickname()
        {
            if (Identity.Identity.IsAuthenticated)
            {
                return Content(Identity.Identity.Name);
            }
            return Content("Anonymous");
        }

        [HttpGet]
        public ActionResult _Login() => View();

        [HttpGet]
        public ActionResult Login() => View();
        [HttpGet]
        public ActionResult _Register() => View();
        public ActionResult Register() => View();


        [HttpPost]
        [AntiForgeryValidate]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                ClaimsIdentity claim = await _userProfileService.Autorization(Mapper.ToBllUserProfileLoginModel(model));

                if (claim != null)
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("StartPage", "Home");
                }
                ModelState.AddModelError("", "Incorrect login or password");
            }
            return View(model);
        }

        [HttpPost]
        [AntiForgeryValidate]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (!(await _userProfileService.UserNameExist(model.Name) && await _userProfileService.UserEmailExist(model.Email)))
                {
                    _userProfileService.CreateUserProfile(Mapper.ToBllUserProfileRegisterModel(model));
                    return RedirectToAction("StartPage", "Home");
                }
                ModelState.AddModelError("", "User with this login or email already exist");
            }
            return View(model);
        }

        public ActionResult Logoff()
        {
            if (User.Identity.IsAuthenticated)
            {
                AuthenticationManager.SignOut();
            }
            return RedirectToAction("StartPage", "Home");
        }

    }
}