using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Data.Entities;

namespace Dialog.Business.Service.Util.MapProfiles
{
    public class MetaContactProfile : Profile
    {
        public MetaContactProfile()
        {
          CreateMap<MetaContact, MetaContactDto>().ReverseMap();
        }
    }
}
