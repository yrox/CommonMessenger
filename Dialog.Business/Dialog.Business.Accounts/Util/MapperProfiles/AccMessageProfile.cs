using AutoMapper;
using Dialog.Business.DTO;

namespace Dialog.Business.Accounts.Util.MapperProfiles
{
    public class AccMessageProfile : Profile
    {
        public AccMessageProfile()
        {
            CreateMap<VkNet.Model.Message, MessageDto>()
                .ForMember("AccountId", x => x.MapFrom(c => c.UserId))
                .ReverseMap();

            CreateMap<TeleSharp.TL.TLAbsMessage, MessageDto>()
                .ForMember("AccountId", x => x.MapFrom(c => (c as TeleSharp.TL.TLMessage).FromId))
                .ReverseMap();
        }
    }
}
