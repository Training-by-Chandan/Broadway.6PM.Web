using Broadway._6PM.Web.Services;
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
        private CustomerService customer = new CustomerService();

        [AllowAnonymous]
        public ActionResult Index() //action
        {
            var data = customer.GetDashboardItem();
            return View(data);
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