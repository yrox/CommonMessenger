using System;
using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Data.Entities;

namespace Dialog.Business.Service.Util.MapProfiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}
