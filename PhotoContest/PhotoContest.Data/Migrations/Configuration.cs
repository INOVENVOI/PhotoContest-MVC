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
                    ProfilePicture =
                        "http://orig08.deviantart.net/ec2f/f/2011/334/f/0/profile_picture_by_kyo_tux-d4hrimy.png",
                    BirthDate = new DateTime(1990, 10, 20),
                    Email = "guster@gmail.com",
                    UserName = "Gustera"
                };

                var minka = new User
                {
                    FullName = "Minka Zlatanova",
                    ProfilePicture = "http://in-the-void.com/hidden/main-alien-grey.jpg",
                    BirthDate = new DateTime(1980, 11, 11),
                    Email = "minka@gmail.com",
                    UserName = "Minka"
                };

                userManager.Create(guster, "123456");
                userManager.Create(minka, "123456");
                context.SaveChanges();

                var natureContest = new Contest
                {
                    Title = "Nature",
                    Description = "Photos of nature, animals and natural phenomenom",
                    OrganizerId = minka.Id,
                    Organizer = minka,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(30),
                    ParticipantsLimit = 10,
                    VotingStrategy = VotingStrategy.Open,
                    ParticipationStrategy = ParticipationStrategy.Open,
                    DeadlineStrategy = DeadlineStrategy.ParticipatantsLimit,
                    ContestStatus = ContestStatus.Active
                };

                var humanContest = new Contest
                {
                    Title = "Humans",
                    Description = "Portrait and human body photography",
                    OrganizerId = guster.Id,
                    Organizer = guster,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(10),
                    VotingStrategy = VotingStrategy.Open,
                    ParticipationStrategy = ParticipationStrategy.Open,
                    DeadlineStrategy = DeadlineStrategy.EndDate,
                    ContestStatus = ContestStatus.Active
                };

                context.Contests.Add(natureContest);
                context.Contests.Add(humanContest);
                context.SaveChanges();

                guster.OrganizedContests.Add(natureContest);
                minka.OrganizedContests.Add(humanContest);

                guster.ParticipatedContests.Add(natureContest);
                guster.ParticipatedContests.Add(humanContest);
                minka.ParticipatedContests.Add(natureContest);
                minka.ParticipatedContests.Add(natureContest);

                context.SaveChanges();
            }
        }
    }
}
