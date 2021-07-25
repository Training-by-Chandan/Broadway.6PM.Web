using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway._6PM.Web.ViewModel
{
    public class RequestViewModel
    {
    }

    public class ResponseViewModel
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; }
    }
}