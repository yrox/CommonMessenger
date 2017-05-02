using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Data.Entities;

namespace Dialog.Business.Service.Util.MapProfiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDto>().ReverseMap();
        }
    }
}
