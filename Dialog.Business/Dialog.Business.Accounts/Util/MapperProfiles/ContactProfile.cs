using System;
using AutoMapper;
using Dialog.Business.DTO;

namespace Dialog.Business.Accounts.Util.MapperProfiles
{
    public class ContactProfile : Profile
    {
        [Obsolete(
            "Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<VkNet.Model.User, ContactDTO>()
                .ForMember("AccountId", x => x.MapFrom(c => c.Id))
                .ForMember("Name", x => x.MapFrom(c => c.FirstName + " " + c.LastName))
                .ReverseMap();
            
            CreateMap<TeleSharp.TL.TLAbsUser, ContactDTO>()
                .ForMember("AccountId", x => x.MapFrom(c => (c as TeleSharp.TL.TLUser).id))
                .ForMember("Name", x => x
                .MapFrom(c => (c as TeleSharp.TL.TLUser).first_name + " " + ((c as TeleSharp.TL.TLUser).last_name) ?? ""))
                .ReverseMap();
        }
    }
}
