using System;
using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Data.Entities;

namespace Dialog.Business.Service.Util.MapProfiles
{
    public class ContactProfile : Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}
