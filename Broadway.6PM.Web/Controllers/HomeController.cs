using Broadway._6PM.Web.Models;
using Broadway._6PM.Web.Services;
using Broadway._6PM.Web.ViewModel;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                var data = customer.GetDashboardItem();
                return View(data);
            }
        }

        public async Task<ActionResult> About(int time = 60000)
        {
            ViewBag.Message = "Your application description page.";
            await DelayClass.Delay(time);
            return View();
        }

        public async Task<ActionResult> Contact()
        {
            ViewBag.Message = "Your contact page.";
            RecurringJob.AddOrUpdate("myrecurringjob",() => DelayClass.DelayFromHagfire(60000), Cron.MonthInterval(2));
            await DelayClass.DelayFromHagfire(60000);
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

    public class DelayClass
    {
        public static async Task Delay(int time = 60000)
        {
            await Task.Delay(time);
        }

        public static async Task DelayFromHagfire(int time = 60000)
        {
            Hangfire.BackgroundJob.Enqueue(() => Task.Delay(time));
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