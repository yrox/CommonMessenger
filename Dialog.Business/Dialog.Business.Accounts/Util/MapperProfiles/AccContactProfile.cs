using System;
using AutoMapper;
using Dialog.Business.DTO;

namespace Dialog.Business.Accounts.Util.MapperProfiles
{
    public class AccContactProfile : Profile
    {
        public AccContactProfile()
        {
            CreateMap<VkNet.Model.User, ContactDto>()
                .ForMember("AccountId", x => x.MapFrom(c => c.Id))
                .ForMember("Name", x => x.MapFrom(c => c.FirstName + " " + c.LastName))
                .ReverseMap();

            CreateMap<TeleSharp.TL.TLAbsUser, ContactDto>()
                .ForMember("AccountId", x => x.MapFrom(c => (c as TeleSharp.TL.TLUser).id))
                .ForMember("Name", x => x
                .MapFrom(c => (c as TeleSharp.TL.TLUser).first_name + " " + ((c as TeleSharp.TL.TLUser).last_name) ?? ""))
                .ReverseMap();
        }
    }
}
