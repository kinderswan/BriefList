using System.Web.Mvc;
using BLL.Interfaces.Interfaces;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult StartPage()=>View();
        public ActionResult MainPage() => View();
    }
}