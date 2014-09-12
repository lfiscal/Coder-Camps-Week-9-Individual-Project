namespace MovieApp.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MovieApp.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieApp.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieApp.Data.ApplicationDbContext context)
        {
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
            var UserStore = new UserStore<ApplicationUser>(context);
            var UserManager = new UserManager<ApplicationUser>(UserStore);
            var RoleStore = new RoleStore<IdentityRole>(context);
            var RoleManager = new RoleManager<IdentityRole>(RoleStore);
            if (!RoleManager.RoleExists("Admin"))
            {
                IdentityRole Role = new IdentityRole("Admin");
                RoleManager.Create(Role);
            }
            if (!RoleManager.RoleExists("User"))
            {
                IdentityRole Role = new IdentityRole("User");
                RoleManager.Create(Role);
            }
            if (!context.Users.Any(u => u.UserName == "Admin@me.com"))
            {
                ApplicationUser User = new ApplicationUser();
                User.UserName = "Admin@me.com";
                UserManager.Create(User, "123456");
                UserManager.AddToRole(User.Id, "Admin");
            }
            //if (!context.Users.Any(u => u.UserName == "User@me.com"))
            //{
            //    ApplicationUser User = new ApplicationUser();
            //    User.UserName = "User@me.com";
            //    UserManager.Create(User, "123456");
            //    UserManager.AddToRole(User.Id, "User");
            //}

        }
    }
}
