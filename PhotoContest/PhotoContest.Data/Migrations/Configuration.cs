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
            //if (context.Pictures.Any())
            //{
            //    return;
            //}

            var userManager = new UserManager<User>(new UserStore<User>(context));

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

            //var deadlineStrategy1 = new DeadlineStrategy
            //{
            //    DeadlineByTime = new DateTime(2010, 12, 31)
            //};

            //var deadlineStrategy2 = new DeadlineStrategy
            //{
            //    DeadlineByParticipantsNumber = 10
            //};

            //context.DeadlineStrategies.Add(deadlineStrategy1);
            //context.DeadlineStrategies.Add(deadlineStrategy2);

            //var camera = new Prize
            //{
            //    Name = "Camera CANON"
            //};

            //var phone = new Prize
            //{
            //    Name = "IPhone 6S"
            //};

            //context.Prizes.Add(camera);
            //context.Prizes.Add(phone);

            //var rewardStrategy = new RewardStrategy
            //{
            //    Winner = guster,
            //    Prizes = new List<Prize> {camera, phone}
            //};

            //context.RewardStrategies.Add(rewardStrategy);

            //var contest = new Contest
            //{
            //    Title = "Nature",
            //    Description = "Photography of nature, animals and phenomenon",
            //    Organizer = minka,
            //    RewardStrategy = rewardStrategy,
            //    VotingStrategy = VotingStrategy.Open,
            //    ParticipationStrategy = ParticipationStrategy.Open,
            //    DeadlineStrategy = deadlineStrategy1,
            //    Participants = new List<User> { guster, minka }
            //};

            //context.Contests.Add(contest);

            //var picture1 = new Picture
            //{
            //    ImageURL =
            //        "http://www.theimaginativeconservative.org/wp-content/uploads/2015/06/Fall-beautiful-nature-22666764-900-562.jpg",
            //    Owner = minka,
            //    Contests = new List<Contest> { contest }
            //};

            //var picture2 = new Picture
            //{
            //    ImageURL =
            //        "http://cdn.banquenationale.ca/cdnbnc/2013/06/ruisseau.jpg",
            //    Owner = guster,
            //    Contests = new List<Contest> { contest }
            //};

            //contest.Pictures.Add(picture1);
            //contest.Pictures.Add(picture2);

            //var vote = new Vote
            //{
            //    Voter = guster,
            //    Picture = picture2,
            //    Contest = contest
            //};

            //context.Votes.Add(vote);

            //context.SaveChanges();
        }
    }
}
