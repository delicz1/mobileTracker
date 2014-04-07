using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using MobileTracker.Models;
using Group = MobileTracker.Models.Group;

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

        private ApplicationDbContext db = new ApplicationDbContext();
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MobileTracker.Models.ApplicationDbContext";
        }

        protected override void Seed(MobileTracker.Models.ApplicationDbContext context)
        {
            this.CreateRoles();
            this.CreateEventTypes();

            var group = new Group()
            {
                Name = "Admin Group",
                Description = "Skupina administratora"
            };
            db.Groups.Add(group);
            db.SaveChanges();

            var idManager = new IdentityManager();
            var user = new ApplicationUser()
            {
                UserName = "admin",
                FirstName = "Dalibor",
                LastName = "Špringer",
                Email = "springer@Example.com",
                GroupId = group.GroupId
            };

            idManager.CreateUser(user, "123456");
            idManager.AddUserToRole(user.Id, IdentityManager.RoleAdmin);
            idManager.AddUserToRole(user.Id, IdentityManager.RoleGroupAdmin);
            idManager.AddUserToRole(user.Id, IdentityManager.RoleUser);

            group = new Group()
            {
                Name = "Basic Group",
                Description = "Zakldni skupina"
            };
            db.Groups.Add(group);
            db.SaveChanges();


            for (int i = 0; i < 4; i++)
            {
                user = new ApplicationUser()
                {
                    UserName = string.Format("User{0}", i.ToString()),
                    FirstName = string.Format("FirstName{0}", i.ToString()),
                    LastName = string.Format("LastName{0}", i.ToString()),
                    Email = string.Format("Email{0}@Example.com", i.ToString()),
                    GroupId = group.GroupId
                };
                idManager.CreateUser(user, string.Format("Password{0}", i.ToString()));
                idManager.AddUserToRole(user.Id, IdentityManager.RoleGroupAdmin);
                idManager.AddUserToRole(user.Id, IdentityManager.RoleUser);
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
            success = idManager.CreateRole(IdentityManager.RoleAdmin);
            if (!success == true) return success;

            // Add the Description as an argument:
            success = idManager.CreateRole(IdentityManager.RoleGroupAdmin);
            if (!success == true) return success;

            // Add the Description as an argument:
            success = idManager.CreateRole(IdentityManager.RoleUser);
            if (!success) return success;

            return success;
        }

        bool CreateEventTypes()
        {
            db.EventTypes.Add(new EventType() { Name = "Zapnutí zaøízení", Icon = "on.png"});
            db.EventTypes.Add(new EventType() { Name = "Vypnutí zaøízení", Icon = "off.png"});
            db.EventTypes.Add(new EventType() { Name = "Stav baterie", Icon = "battery.png"});
            db.EventTypes.Add(new EventType() { Name = "Stav signálu", Icon = "signal.png" });
            return db.SaveChanges() == 4;
        }
    }
}
