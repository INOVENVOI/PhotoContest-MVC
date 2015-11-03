using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoContest.Web.App_Start
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Models.ViewModels;
    using PhotoContext.Models;

    public static class MapperConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.CreateMap<Picture, PictureDetailsViewModel>()
                .ForMember(model => model.Author, config => config.MapFrom(photo => photo.Owner.UserName));

            Mapper.CreateMap<Contest, ContestDetailsViewModel>()
                .ForMember(c => c.Organizier, cfg => cfg.MapFrom(c => c.Organizer.UserName))
                .ForMember(c => c.PicturesCount, cfg => cfg.MapFrom(c => c.Pictures.Count))
                .ForMember(c => c.Prizes, cfg => cfg.MapFrom(c => c.Prizes.AsQueryable().ProjectTo<PrizeViewModel>()))
                .ForMember(c => c.ParticipantsCount, cfg => cfg.MapFrom(c => c.Participants.Count));

            Mapper.CreateMap<Contest, ContestSummaryViewModel>()
                .ForMember(c => c.Organizier, cfg => cfg.MapFrom(c => c.Organizer.UserName));

            Mapper.CreateMap<Picture, PictureDetailsViewModel>()
                .ForMember(p => p.Author, cfg => cfg.MapFrom(p => p.Owner.UserName))
                .ForMember(p => p.ContestsCount, cfg => cfg.MapFrom(p => p.Contests.Count))
                .ForMember(p => p.VotesCount, cfg => cfg.MapFrom(p => p.Votes.Count));

            Mapper.CreateMap<Picture, PictureSummaryViewModel>()
                .ForMember(p => p.Author, cfg => cfg.MapFrom(p => p.Owner.UserName))
                .ForMember(p => p.VotesCount, cfg => cfg.MapFrom(p => p.Votes.Count));

            Mapper.CreateMap<User, UserDetailsViewModel>()
                .ForMember(p => p.PicturesCount, cfg => cfg.MapFrom(p => p.Pictures.Count))
                .ForMember(p => p.OrganizedContestsCount, cfg => cfg.MapFrom(p => p.OrganizedContests.Count))
                .ForMember(p => p.ParticipatedContestsCount, cfg => cfg.MapFrom(p => p.ParticipatedContests.Count));

        }
    }
}