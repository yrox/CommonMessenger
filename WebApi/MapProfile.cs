using System;

namespace WebApi
{
    public class MapProfile : AutoMapper.Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<DTOs.ContactDTO, Data.Entities.Contact>();
            CreateMap<DTOs.MetaContactDTO, Data.Entities.MetaContact>();
            CreateMap<Data.Entities.Contact, DTOs.ContactDTO >();
            CreateMap<Data.Entities.MetaContact, DTOs.MetaContactDTO>();

        }
    }
}