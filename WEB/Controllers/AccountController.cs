﻿using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Interfaces;
using Microsoft.Owin.Security;
using WEB.Mapping;
using WEB.Models;


namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        public AccountController(IUserProfileService userProfileService)
        {
            this._userProfileService = userProfileService;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        private ClaimsPrincipal Identiti
        {
            get
            {
                return (ClaimsPrincipal)Thread.CurrentPrincipal;
            }
        }


        [ChildActionOnly]
        public ActionResult Nikneim()
        {           
            if (Identiti.Identity.IsAuthenticated) return Content(Identiti.Identity.Name);
            return Content("Anonymous");
        }

        [HttpGet]
        public ActionResult _Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                ClaimsIdentity claim = await _userProfileService.Autorization(Mapper.ToBllUserProfileLoginModel(model));

                if (claim!=null)
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("", "Incorrect login or password");
            }
            return View(model);
        }



        [HttpGet]
        public ActionResult _Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (!(await _userProfileService.UserNameExist(model.Name) && await _userProfileService.UserEmailExist(model.Email)))
                {
                    _userProfileService.CreateUserProfile(Mapper.ToBllUserProfileRegisterModel(model));
                    return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Index", "Home");
        }

    }

}