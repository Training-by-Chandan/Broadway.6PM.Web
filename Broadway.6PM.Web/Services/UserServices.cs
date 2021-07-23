using Broadway._6PM.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Broadway._6PM.Web.ViewModel.Admin;

namespace Broadway._6PM.Web.Services
{
    public class UserServices
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<UserlistViewModel> GetAllUsers()
        {
            //var userStore = new UserStore<ApplicationUser>(db);
            //var userManager = new UserManager<ApplicationUser>(userStore);
            var data = db.Users.Select(p => new UserlistViewModel
            {
                Id = p.Id,
                Email = p.Email,
                Username = p.UserName
            });
            return data.ToList();
        }
    }
}