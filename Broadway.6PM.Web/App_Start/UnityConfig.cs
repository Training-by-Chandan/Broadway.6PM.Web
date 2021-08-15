using Broadway._6PM.Web.Models;
using Broadway._6PM.Web.Repositories;
using Broadway._6PM.Web.Services;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace Broadway._6PM.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IUserServices, UserServices>();
            container.RegisterType<IVendorServices, VendorServices>();
            container.RegisterType<DbContext, ApplicationDbContext>(new PerThreadLifetimeManager());
            container.RegisterType<IBaseRepository<Vendors>, VendorRepository>();

            container.RegisterSingleton(typeof(Broadway._6PM.Web.Singleton));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}