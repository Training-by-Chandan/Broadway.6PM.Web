using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway._6PM.Web.ViewModel
{
    public class CartViewModel
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }

    public class CartSessionViewModel
    {
        public CartSessionViewModel()
        {
            this.CartItems = new List<CartViewModel>();
        }

        public List<CartViewModel> CartItems { get; set; }
    }
}