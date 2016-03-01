using System.Web.Mvc;

namespace Epam.BriefList.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult StartPage()=>View();
        public ActionResult Start() => View();
        public ActionResult MainPage() => View();
        public ActionResult Index() => View();
    }
}