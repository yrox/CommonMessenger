using System;

namespace WebApi
{
    public class MapProfile : AutoMapper.Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<DTOs.ContactDTO, Data.Business.Entities.Contact>();
            CreateMap<DTOs.MetaContactDTO, Data.Business.Entities.MetaContact>();

            CreateMap<Data.Business.Entities.Contact, DTOs.ContactDTO >();
            CreateMap<Data.Business.Entities.MetaContact, DTOs.MetaContactDTO>();

            CreateMap<Data.Business.Entities.Message, DTOs.MessageDTO>();
            CreateMap<DTOs.MessageDTO, Data.Business.Entities.Message>();

            CreateMap<Data.Identity.Entities.Account, DTOs.AccountDTO>();
            CreateMap<DTOs.AccountDTO, Data.Identity.Entities.Account>();

        }
    }
}