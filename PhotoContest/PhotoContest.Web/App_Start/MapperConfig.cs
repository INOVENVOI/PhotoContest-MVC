using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoContest.Web.App_Start
{
    using AutoMapper;
    using Models.ViewModels;
    using PhotoContext.Models;

    public static class MapperConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.CreateMap<Picture, PictureDetailsViewModel>()
                .ForMember(model => model.Author, config => config.MapFrom(photo => photo.Owner.UserName));
        }
    }
}