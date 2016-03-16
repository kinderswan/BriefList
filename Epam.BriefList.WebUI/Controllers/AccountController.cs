using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.WebUI.Filters;
using Epam.BriefList.WebUI.HelperExtension;
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

        [System.Web.Mvc.HttpGet]
        public ActionResult Login() => View();
        [System.Web.Mvc.HttpGet]
        public ActionResult Register() => View();


        [System.Web.Mvc.HttpPost]
        [AntiForgeryValidate]
        public async Task<JsonResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ModelState.Errors());
            }
            ClaimsIdentity claim = await _userProfileService.Autorization(Mapper.ToBllUserProfileLoginModel(model));

                if (claim != null)
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return Json(new HttpResponseMessage(HttpStatusCode.NoContent));
                }
                ModelState.AddModelError("Error", "Incorrect login or password");
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(ModelState.Errors());
        }
   

        [System.Web.Mvc.HttpPost]
        [AntiForgeryValidate]
        public async Task<JsonResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ModelState.Errors());
            }
            if (!(await _userProfileService.UserNameExist(model.Name) && await _userProfileService.UserEmailExist(model.Email)))
                {
                    _userProfileService.CreateUserProfile(Mapper.ToBllUserProfileRegisterModel(model));
                    return Json(new HttpResponseMessage(HttpStatusCode.NoContent));
                }
                ModelState.AddModelError("Error", "User with this login or email already exist");
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(ModelState.Errors());
        }



        [System.Web.Mvc.HttpPost]
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