using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway._6PM.Web.ViewModel
{
    public class ProductImageUploadViewModel
    {
        public int Id { get; set; }
        public HttpPostedFileBase[] File { get; set; }
    }
}