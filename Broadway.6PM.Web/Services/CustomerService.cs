using Broadway._6PM.Web.Models;
using Broadway._6PM.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway._6PM.Web.Services
{
    public class CustomerService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public FrontPageViewModel GetDashboardItem()
        {
            var products = db.Products.GroupBy(p => p.CategoryId).Select(p => new ItemCollectionViewModel
            {
                CategoryId = p.Key,
                CategoryName = p.FirstOrDefault().Category.Name,
                Products = p.Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Stock = x.NumberofStock
                }).ToList()
            });

            return new FrontPageViewModel() { Items = products.ToList() };
        }
    }
}