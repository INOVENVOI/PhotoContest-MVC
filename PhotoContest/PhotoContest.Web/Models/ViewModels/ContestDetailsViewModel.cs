namespace PhotoContest.Web.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PagedList;
    using PhotoContext.Models;

    public class ContestDetailsViewModel : IPagedList
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public UserDetailsViewModel Organizer { get; set; }

        public UserDetailsViewModel Winner { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Display(Name = "Pictures in contest")]
        public int PicturesCount { get; set; }

        [Display(Name = "Participants in contest")]
        public int ParticipantsCount { get; set; }

        public VotingStrategy VotingStrategy { get; set; }

        public ParticipationStrategy ParticipationStrategy { get; set; }

        public DeadlineStrategy DeadlineStrategy { get; set; }

        public ContestStatus ContestStatus { get; set; }

        public IEnumerable<PrizeViewModel> Prizes { get; set; }

        public IEnumerable<PictureSummaryViewModel> Pictures { get; set; }

        public static Expression<Func<Contest, ContestDetailsViewModel>> Create
        {
            get
            {
                return c => new ContestDetailsViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Organizer = new UserDetailsViewModel
                    {
                        FullName = c.Organizer.FullName,
                        Username = c.Organizer.UserName,
                        Email = c.Organizer.Email
                    },
                    Winner = new UserDetailsViewModel
                    {
                        FullName = c.Winner.FullName,
                        Username = c.Winner.UserName,
                        Email = c.Winner.Email
                    },
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    PicturesCount = c.Pictures.Count,
                    ParticipantsCount = c.Participants.Count,
                    VotingStrategy = c.VotingStrategy,
                    ParticipationStrategy = c.ParticipationStrategy,
                    DeadlineStrategy = c.DeadlineStrategy,
                    ContestStatus = c.ContestStatus
                };
            }
        }

        //public void CreateMappings(IConfiguration configuration)
        //{
        //    configuration.CreateMap<Contest, ContestDetailsViewModel>()
        //        .ForMember(c => c.Organizier, cfg => cfg.MapFrom(c => c.Organizer.UserName))
        //        .ForMember(c => c.PicturesCount, cfg => cfg.MapFrom(c => c.Pictures.Count))
        //        .ForMember(c => c.Prizes, cfg => cfg.MapFrom(c => c.Prizes.AsQueryable().ProjectTo<PrizeViewModel>()))
        //        .ForMember(c => c.ParticipantsCount, cfg => cfg.MapFrom(c => c.Participants.Count));
        //}

        public int PageCount { get; set; }
        public int TotalItemCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int FirstItemOnPage { get; set; }
        public int LastItemOnPage { get; set; }
    }
}