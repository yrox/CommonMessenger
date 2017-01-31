using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DTOs;

namespace Business.Mappers
{
    public class EntytiesMapper
    {
        private static DateTime ConvertFromUnixTimestamp(int timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(timestamp);
        }

        public static ContactDTO Map(VkNet.Model.User vkContact)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<VkNet.Model.User, ContactDTO>()
                .ForMember("ContactIdentifier", x => x.MapFrom(c => c.Id))
                .ForMember("Name", x => x.MapFrom(c => c.FirstName + " " + c.LastName)));
            var contact = Mapper.Map<VkNet.Model.User, ContactDTO>(vkContact);
            return contact;
        }
        public static IEnumerable<ContactDTO> Map(IEnumerable<VkNet.Model.User> vkContacts)
        {
            return vkContacts.Select(Map).ToList();
        }

        public static ContactDTO Map(TeleSharp.TL.TLAbsUser contact)
        {
            var tlContact = contact as TeleSharp.TL.TLUser;
            if (tlContact.last_name != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TeleSharp.TL.TLUser, ContactDTO>()
                .ForMember("ContactIdentifier", x => x.MapFrom(c => c.id))
                .ForMember("Name", x => x.MapFrom(c => c.first_name + " " + c.last_name))
                .ForMember("PhoneNumber", x => x.MapFrom(c => c.phone)));
            }
            else
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TeleSharp.TL.TLUser, ContactDTO>()
                .ForMember("ContactIdentifier", x => x.MapFrom(c => c.id))
                .ForMember("Name", x => x.MapFrom(c => c.first_name))
                .ForMember("PhoneNumber", x => x.MapFrom(c => c.phone)));
            }
            var result = Mapper.Map<TeleSharp.TL.TLAbsUser, ContactDTO>(tlContact);
            return result;
        }
        public static IEnumerable<ContactDTO> Map(IEnumerable<TeleSharp.TL.TLAbsUser> tlConEnumerable)
        {
            return tlConEnumerable.Select(Map).ToList();
        }


        
    }
}
