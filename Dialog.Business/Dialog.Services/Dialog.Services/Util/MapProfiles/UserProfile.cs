using System;
using AutoMapper;
using Dialog.DTOs;
using Olga.Identity;

namespace Dialog.Services.Util.MapProfiles
{
    public class UserProfile : Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<AppUser, UserDTO>().ReverseMap();
        }
    }
}
