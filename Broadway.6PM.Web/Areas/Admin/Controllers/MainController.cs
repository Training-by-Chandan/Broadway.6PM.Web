using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Broadway._6PM.Web.Services;
using Broadway._6PM.Web.ViewModel.Admin;

namespace Broadway._6PM.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MainController : Controller
    {
        private UserServices userServices = new UserServices();

        // GET: Admin/Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserManagers()
        {
            var data = userServices.GetAllUsers();
            return View(data);
        }

        [HttpGet]
        public ActionResult Vendors()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateVendors(VendorsCreateRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Vendors",model);
            }
        }
    }
}