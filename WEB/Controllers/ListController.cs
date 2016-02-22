using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class ListController : Controller
    {

        public ActionResult ShowLists()
        {
            return View();
        }
    }
}