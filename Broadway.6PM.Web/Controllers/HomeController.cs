﻿using Broadway._6PM.Web.Models;
using Broadway._6PM.Web.Services;
using Broadway._6PM.Web.ViewModel;
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
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index(int id = 0) //action
        {
            if (id == 1)
            {
                throw new SomeException("");
            }
            else if (id == 2)
            {
                return null;
            }
            else
            {
                // var data = customer.GetDashboardItem();
                return View();
            }
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

        public ActionResult AddToCart(int id)
        {
            //todo : add item to cart

            var cart = Session[ConstString.CartSession] as CartSessionViewModel;
            if (cart == null)
            {
                cart = new CartSessionViewModel();
                var product = db.Products.Find(id);
                if (product != null)
                {
                    var cartitem = new CartViewModel
                    {
                        ProductId = product.Id,
                        Price = product.Price
                    };
                    cartitem.Count++;
                    cart.CartItems.Add(cartitem);
                }
            }
            else
            {
                var existingProduct = cart.CartItems.FirstOrDefault(p => p.ProductId == id);
                if (existingProduct == null)
                {
                    var product = db.Products.Find(id);
                    if (product != null)
                    {
                        var cartitem = new CartViewModel
                        {
                            ProductId = product.Id,
                            Price = product.Price
                        };
                        cartitem.Count++;
                        cart.CartItems.Add(cartitem);
                    }
                }
                else
                {
                    existingProduct.Count++;
                }
            }

            Session[ConstString.CartSession] = cart;
            // Session.Timeout = 1;

            return RedirectToAction("index");
        }

        public ActionResult failedAction()
        {
            try
            {
                FailureClass.FailedTest();
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public ActionResult AjaxCategories()
        {
            return View();
        }
    }

    [Serializable]
    public class SomeException : Exception
    {
        public SomeException()
        {
        }

        public SomeException(string message) : base(message)
        {
        }

        public SomeException(string message, Exception inner) : base(message, inner)
        {
        }

        protected SomeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}