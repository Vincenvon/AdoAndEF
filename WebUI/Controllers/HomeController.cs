using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {

        public PartialViewResult Index()
        {
            return PartialView();
        }
    }
}