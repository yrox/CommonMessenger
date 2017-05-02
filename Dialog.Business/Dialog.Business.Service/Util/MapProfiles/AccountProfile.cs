using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Data.Entities;

namespace Dialog.Business.Service.Util.MapProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}
