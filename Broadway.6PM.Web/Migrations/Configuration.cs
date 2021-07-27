namespace Broadway._6PM.Web.Migrations
{
    using Broadway._6PM.Web.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Broadway._6PM.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Broadway._6PM.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(Broadway._6PM.Web.Models.ApplicationDbContext db)
        {
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            #region admin user seed

            if (!(db.Roles.Any(p => p.Name == ConstString.Roles.Admin)))
            {
                roleManager.Create(new IdentityRole() { Name = ConstString.Roles.Admin });
            }
            if (!(db.Roles.Any(p => p.Name == ConstString.Roles.Vendors)))
            {
                roleManager.Create(new IdentityRole() { Name = ConstString.Roles.Vendors });
            }

            if (!(db.Users.Any(u => u.UserName == "admin@admin.com")))
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "admin@admin.com", PhoneNumber = "12345678911", Email = "admin@admin.com" };
                userManager.Create(userToInsert, "Admin@123");

                userManager.AddToRole(userToInsert.Id, ConstString.Roles.Admin);
            }

            #endregion admin user seed
        }
    }
}