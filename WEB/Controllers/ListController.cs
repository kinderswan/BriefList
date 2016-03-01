﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Interfaces;
using WEB.Mapping;

namespace WEB.Controllers
{
    public class ListController : Controller
    {
        private readonly IListService _listService;
        public ListController(IListService listService)
        {
            this._listService = listService;
        }

    }
}