using System.Web.Mvc;
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
            return View();
        }

    }
}