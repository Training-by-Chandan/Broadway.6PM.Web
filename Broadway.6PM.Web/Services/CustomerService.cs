using Broadway._6PM.Web.Models;
using Broadway._6PM.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway._6PM.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private ApplicationDbContext db;

        public CustomerService(ApplicationDbContext db)
        {
            this.db = db;
        }

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
                    Stock = x.NumberofStock,
                    Images = x.Images.Select(y => new ImageViewModel()
                    {
                        FilePath = y.ImagePath
                    }).ToList()
                }).ToList()
            });

            return new FrontPageViewModel() { Items = products.ToList() };
        }
    }

    public class FailureClass
    {
        public static void FailedTest()
        {
            try
            {
                FailureClass2.FailedTest();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class FailureClass2
    {
        public static void FailedTest()
        {
            try
            {
                FailureClass3.FailedTest();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class FailureClass3
    {
        public static void FailedTest()
        {
            try
            {
                int[] i = new int[2];
                i[0] = 1;
                i[1] = 2;
                i[2] = 3;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}