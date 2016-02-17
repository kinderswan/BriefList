using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Nikneim()
        {
            //эт нужно!! 
            //if (Identiti.Identity.IsAuthenticated) return Content(Identiti.Identity.Name + "(" + Identiti.Identity.GetUserRole() + ")");
            return Content("Anonymous");
        }

     //   [HttpGet]
        public ActionResult _Login()
        {
            var x = Request.IsAjaxRequest();
            return View();
        }

    }
}