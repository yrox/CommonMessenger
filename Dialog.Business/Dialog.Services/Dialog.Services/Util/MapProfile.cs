using System;
using Dialog.Data.Entities;
using Dialog.DTOs;

namespace Dialog.Services.Util
{
    public class MapProfile : AutoMapper.Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<MetaContact, MetaContactDTO>().ReverseMap();
            CreateMap<Message, MessageDTO>().ReverseMap();
            CreateMap<Account, AccountDTO>().ReverseMap();

        }
    }
}