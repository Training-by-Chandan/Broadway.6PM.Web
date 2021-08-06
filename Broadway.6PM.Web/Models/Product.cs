using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Broadway._6PM.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Categories Category { get; set; }

        public int NumberofStock { get; set; }
        public double Price { get; set; }
        public int VendorId { get; set; }

        [ForeignKey("VendorId")]
        public virtual Vendors Vendors { get; set; }

        public ICollection<ImageResource> Images { get; set; }
    }

    public class ImageResource
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}