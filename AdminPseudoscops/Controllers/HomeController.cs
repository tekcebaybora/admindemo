using System.Web.Mvc;
using AdminPseudoscops.Models;
using AdminPseudoscops.Models.AppModel;
using System.Data.Entity;
using System.Linq;


namespace AdminPseudoscops.Controllers
{
    [Authorize]
    //[Authorize(Roles = "Admin, AnotherRole")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult HomePageTitles()
        {
            HomePageViewTitles model = new HomePageViewTitles();

            using (AzureDbContext db = new AzureDbContext())
            {
                model.TotalAccessEvent = db.EventHistory.Count();
                model.TotalActiveApplicationUser = db.GateAccessUser.Count();
                model.TotalActiveDevices = db.Devices.Where(d => d.IsActive == 1).Count();
            }
            ViewBag.Message = "Your contact page.";

            return PartialView(model);
        }

        public ActionResult MenuSideBar()
        {
            return PartialView();
        }
        public ActionResult TopBar()
        {
            return PartialView();
        }

        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}