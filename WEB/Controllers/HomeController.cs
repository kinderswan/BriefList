﻿using ORM;
using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
     /*       EntityModelContext db = new EntityModelContext();
            db.Set<OrmList>().Add(new OrmList()
            {
                Id = 2,
                Description = "This role is a visitor of auction",
                OrmUserProfiles = new List<OrmUserProfile>()
                {
                    new OrmUserProfile() { Id=2, Name="vad", Email="tito@tut.by", Password="APqUWHeWTozEWzwv0SFfkXKGaavpRbijLRsmT/6ucSQ344UtCgqm5YOw74Bp4Z2rBg==",TimeRegister = DateTime.Now  }
                }
            });
            db.SaveChanges();*/
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult _Login()
        {
            var x = Request.IsAjaxRequest();
            return View();
        }
    }
}