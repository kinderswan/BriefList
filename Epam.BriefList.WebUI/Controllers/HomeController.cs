using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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