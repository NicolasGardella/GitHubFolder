using LaCocinaDeFanny.Persistencia;
using System;
using System.Web;
using System.Web.Mvc;

namespace LaCocinaDeFanny.Controllers
{

    [RequireHttps]
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
        [Authorize]
        public ActionResult ProtectedPage()
        {
            ViewBag.UserName = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Agenda()
        {
            new ClaseRepository().CrearClase(new DateTime(2020,01,27,11,00,00),new TimeSpan(2,0,0),int.Parse(Session["id"].ToString()),100,0,1,"","Fisica");
            return View();
        }
    }
}