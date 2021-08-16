using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Broadway._6PM.Web.Reports
{
    public partial class GeneralReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ReportViewer1.Height = Unit.Pixel(600);
                    ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                    ReportViewer1.ServerReport.ReportServerUrl = new Uri("https://localhost/ReportServer");
                    ReportViewer1.ServerReport.ReportPath = Request.QueryString.Get("name");
                    ReportViewer1.ServerReport.Refresh();
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}