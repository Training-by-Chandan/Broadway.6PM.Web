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
        private VendorServices vendorServices = new VendorServices();

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

        public ActionResult VendorList()
        {
            var data = vendorServices.GetAllVendors();
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
                //enter the data
                var res = vendorServices.CreateVendors(model);
                if (res.Status)
                {
                    return RedirectToAction("VendorList");
                }
                else
                {
                    ViewBag.Result = res;
                }
            }
            return View("Vendors", model);
        }

        [HttpGet]
        public ActionResult Editvendor(int id)
        {
            var vendor = vendorServices.GetVendorById(id);

            return View(vendor);
        }

        [HttpPost]
        public ActionResult EditVendor(VendorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = vendorServices.EditVendor(model);
                if (res.Status)
                {
                    return RedirectToAction("VendorList");
                }
            }
            return View(model);
        }
    }
}