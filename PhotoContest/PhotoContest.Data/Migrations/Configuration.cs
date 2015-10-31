namespace PhotoContest.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PhotoContext.Models;
    

    public sealed class Configuration : DbMigrationsConfiguration<PhotoContest.Data.PhotoDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhotoContest.Data.PhotoDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                roleManager.Create(new IdentityRole { Name = "Administrator" });
            }

            // if user doesn't exist, create one and add it to the Administrator role
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                var admin = new User
                {
                    FullName = "Administrator",
                    UserName = "admin",
                    Email = "admin@admin.com"
                };
                
                userManager.Create(admin, "123456");
                userManager.AddToRole(admin.Id, "Administrator");

                var guster = new User
                {
                    FullName = "Guster Comodski",
                    Email = "guster@gmail.com",
                    UserName = "guster@gmail.com"
                };

                var minka = new User
                {
                    FullName = "Minka Zlatanova",
                    Email = "minka@gmail.com",
                    UserName = "minka@gmail.com"
                };

                userManager.Create(guster, "123456");
                userManager.Create(minka, "123456");
            }
        }
    }
}
