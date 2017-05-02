using AutoMapper;
using Dialog.Business.DTO;
using Olga.Identity;

namespace Dialog.Business.Service.Util.MapProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
