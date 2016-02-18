using ORM;
using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.BLLModels;
using BLL.Interfaces.Interfaces;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        public HomeController(IUserProfileService userProfileService)
        {
            this._userProfileService = userProfileService;
        }


        public ActionResult Index()
        {
            _userProfileService.CreateUserProfile(new BllUserProfile
            {
                TimeRegister = DateTime.Now,
                Password = "000000", 
                Name = "tyttty",                
            });
            return View();
        }

    }
}