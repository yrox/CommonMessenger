using System;
using AutoMapper;
using Dialog.Data.Entities;
using Dialog.DTOs;

namespace Dialog.Services.Util.MapProfiles
{
    public class MetaContactProfile : Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
          CreateMap<MetaContact, MetaContactDTO>().ReverseMap();
        }
    }
}
