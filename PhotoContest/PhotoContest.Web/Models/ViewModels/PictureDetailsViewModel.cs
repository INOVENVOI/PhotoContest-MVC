﻿using System;
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

    public class PictureDetailsViewModel : IPagedList
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageURL { get; set; }

        [Display(Name = "Votes")]
        public int VotesCount { get; set; }

        public UserDetailsViewModel Author { get; set; }

        public DateTime PostedOn { get; set; }

        [Display(Name = "Photo in contests")]
        public int ContestsCount { get; set; }

        public static Expression<Func<Picture, PictureDetailsViewModel>> Create
        {
            get
            {
                return p => new PictureDetailsViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageURL = p.ImageURL,
                    VotesCount = p.Votes.Count,
                    Author = new UserDetailsViewModel
                    {
                        FullName = p.Owner.FullName,
                        Username = p.Owner.UserName,
                        Email = p.Owner.Email,
                        PicturesCount = p.Owner.Pictures.Count
                    },
                    PostedOn = p.PostedOn,
                    ContestsCount = p.Contests.Count
                };
            }
        }

        //public void CreateMappings(IConfiguration configuration)
        //{
        //    configuration.CreateMap<Picture, PictureDetailsViewModel>()
        //        .ForMember(p => p.Author, cfg => cfg.MapFrom(p => p.Owner.UserName))
        //        .ForMember(p => p.ContestsCount, cfg => cfg.MapFrom(p => p.Contests.Count))
        //        .ForMember(p => p.VotesCount, cfg => cfg.MapFrom(p => p.Votes.Count));
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