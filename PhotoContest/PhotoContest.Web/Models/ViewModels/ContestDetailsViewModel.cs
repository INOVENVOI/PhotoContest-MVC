using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoContest.Web.Models.ViewModels
{
    using System.Linq.Expressions;
    using PhotoContext.Models;

    public class ContestDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public UserDetailsViewModel Organizier { get; set; }

        public int PicturesCount { get; set; }

        public int ParticipantsCount { get; set; }

        public VotingStrategy VotingStrategy { get; set; }

        public ParticipationStrategy ParticipationStrategy { get; set; }

        public DeadlineStrategyViewModel DeadlineStrategy { get; set; }

        public static Expression<Func<Contest, ContestDetailsViewModel>> Create
        {
            get
            {
                return c => new ContestDetailsViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Organizier = new UserDetailsViewModel
                    {
                        FullName = c.Organizer.FullName,
                        Username = c.Organizer.UserName,
                        Email = c.Organizer.Email,
                        PicturesCount = c.Organizer.Pictures.Count
                    },
                    PicturesCount = c.Pictures.Count,
                    ParticipantsCount = c.Participants.Count,
                    VotingStrategy = c.VotingStrategy,
                    ParticipationStrategy = c.ParticipationStrategy,
                    DeadlineStrategy = new DeadlineStrategyViewModel
                    {
                        DeadlineByTime = c.DeadlineStrategy.DeadlineByTime,
                        DeadlineByParticipantsNumber = c.DeadlineStrategy.DeadlineByParticipantsNumber
                    }
                };
            }
        }
    }
}