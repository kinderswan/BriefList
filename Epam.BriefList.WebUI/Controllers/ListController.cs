using System.Web.Mvc;
using Epam.BriefList.Services.API.Interfaces;

namespace Epam.BriefList.WebUI.Controllers
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