using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoContest.Web.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using PagedList;
    using PhotoContext.Models;

    public class PictureDetailsViewModel : IPagedList
    {
        public int Id { get; set; }

        public string ImageURL { get; set; }

        [Display(Name = "Votes")]
        public int VotesCount { get; set; }

        public UserDetailsViewModel Author { get; set; }

        [Display(Name = "Photo in contests")]
        public int ContestsCount { get; set; }

        public static Expression<Func<Picture, PictureDetailsViewModel>> Create
        {
            get
            {
                return p => new PictureDetailsViewModel
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    VotesCount = p.Votes.Count,
                    Author = new UserDetailsViewModel
                    {
                        FullName = p.Owner.FullName,
                        Username = p.Owner.UserName,
                        Email = p.Owner.Email,
                        PicturesCount = p.Owner.Pictures.Count
                    },
                    ContestsCount = p.Contests.Count
                };
            }
        }
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