using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoContest.Web.Models.ViewModels
{
    using System.Linq.Expressions;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PagedList;
    using PhotoContext.Models;

    public class ContestSummaryViewModel :IPagedList
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public UserSummaryViewModel Organizier { get; set; }

        public ContestStatus ContestStatus { get; set; }

        
        public static Expression<Func<Contest, ContestSummaryViewModel>> Create
        {
            get
            {
                return c => new ContestSummaryViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Organizier = new UserSummaryViewModel
                    {
                        FullName = c.Organizer.FullName,
                        Username = c.Organizer.UserName
                        
                    },
                    ContestStatus = c.ContestStatus
                };
            }
        }

        //public void CreateMappings(IConfiguration configuration)
        //{
        //    configuration.CreateMap<Contest, ContestSummaryViewModel>()
        //        .ForMember(c => c.Organizier, cfg => cfg.MapFrom(c => c.Organizer.UserName));
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