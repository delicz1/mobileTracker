using MobileTracker.Models;

namespace MobileTracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<MobileTracker.Models.ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MobileTracker.Models.ApplicationDbContext";
        }

        protected override void Seed(MobileTracker.Models.ApplicationDbContext context)
        {

            bool success;
            this.CreateRoles();

            var idManager = new IdentityManager();
            var user = new ApplicationUser()
            {
                UserName = "admin",
                FirstName = "Dalibor",
                LastName = "Špringer",
                Email = "springer@Example.com"
            };

            idManager.CreateUser(user, "123456");
            idManager.AddUserToRole(user.Id, "Admin");
            idManager.AddUserToRole(user.Id, "GroupAdmin");
            idManager.AddUserToRole(user.Id, "User");

            for (int i = 0; i < 4; i++)
            {
                user = new ApplicationUser()
                {
                    UserName = string.Format("User{0}", i.ToString()),
                    FirstName = string.Format("FirstName{0}", i.ToString()),
                    LastName = string.Format("LastName{0}", i.ToString()),
                    Email = string.Format("Email{0}@Example.com", i.ToString()),
                };
                idManager.CreateUser(user, string.Format("Password{0}", i.ToString()));
                idManager.AddUserToRole(user.Id, "Admin");
                idManager.AddUserToRole(user.Id, "User");
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        bool CreateRoles()
        {
            bool success = false;
            var idManager = new IdentityManager();

            // Add the Description as an argument:
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;

            // Add the Description as an argument:
            success = idManager.CreateRole("GroupAdmin");
            if (!success == true) return success;

            // Add the Description as an argument:
            success = idManager.CreateRole("User");
            if (!success) return success;

            return success;
        }
    }
}
