using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Broadway._6PM.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller //controller
    {
        [AllowAnonymous]
        public ActionResult Index() //action
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

        public ActionResult Test(string name, string email)
        {
            return View();
        }
    }
}