using Broadway._6PM.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Broadway._6PM.Web.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index(string path)
        {
            var report = new ReportViewModel
            {
                Path = "../../Reports/GeneralReport.aspx?name=" + path
            };
            return View(report);
        }
    }
}