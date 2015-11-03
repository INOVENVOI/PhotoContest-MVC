using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoContest.Web.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using AutoMapper;
    using PagedList;
    using PhotoContext.Models;

    public class UserDetailsViewModel : IPagedList
    {
        public string Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [Display(Name = "Photos in contest")]
        public int PicturesCount { get; set; }

        [Display(Name = "Organized contests")]
        public int OrganizedContestsCount { get; set; }

        [Display(Name = "Participated contests")]
        public int ParticipatedContestsCount { get; set; }

        public static Expression<Func<User, UserDetailsViewModel>> Create
        {
            get
            {
                return u => new UserDetailsViewModel
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Username = u.UserName,
                    Email = u.Email,
                    PicturesCount = u.Pictures.Count,
                    OrganizedContestsCount = u.OrganizedContests.Count,
                    ParticipatedContestsCount = u.ParticipatedContests.Count
                };
            }
        }

        //public void CreateMappings(IConfiguration configuration)
        //{
        //    configuration.CreateMap<User, UserDetailsViewModel>()
        //        .ForMember(p => p.PicturesCount, cfg => cfg.MapFrom(p => p.Pictures.Count))
        //        .ForMember(p => p.OrganizedContestsCount, cfg => cfg.MapFrom(p => p.OrganizedContests.Count))
        //        .ForMember(p => p.ParticipatedContestsCount, cfg => cfg.MapFrom(p => p.ParticipatedContests.Count));
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