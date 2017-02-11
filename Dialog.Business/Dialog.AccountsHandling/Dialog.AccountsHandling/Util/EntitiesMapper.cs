using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dialog.DTOs;

namespace Dialog.AccountsHandling.Util
{
    public class EntitiesMapper
    {
        public static DateTime ConvertFromUnixTimestamp(int timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(timestamp);
        }

        public static ContactDTO Map(VkNet.Model.User vkContact)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<VkNet.Model.User, ContactDTO>()
                .ForMember("AccountId", x => x.MapFrom(c => c.Id))
                .ForMember("Name", x => x.MapFrom(c => c.FirstName + " " + c.LastName)));
            return Mapper.Map<VkNet.Model.User, ContactDTO>(vkContact); ;
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
                .ForMember("AccountId", x => x.MapFrom(c => c.id))
                .ForMember("Name", x => x.MapFrom(c => c.first_name + " " + c.last_name)));
            }
            else
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TeleSharp.TL.TLUser, ContactDTO>()
                .ForMember("AccountId", x => x.MapFrom(c => c.id))
                .ForMember("Name", x => x.MapFrom(c => c.first_name)));
            }
            return Mapper.Map<TeleSharp.TL.TLAbsUser, ContactDTO>(tlContact);
        }

        public static IEnumerable<ContactDTO> Map(IEnumerable<TeleSharp.TL.TLAbsUser> tlConEnumerable)
        {
            return tlConEnumerable.Select(Map).ToList();
        }

        public static MessageDTO Map(VkNet.Model.Message vkMessage)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<VkNet.Model.Message, MessageDTO>()
                .ForMember("AccountId", x => x.MapFrom(c => c.UserId)));
            return Mapper.Map<VkNet.Model.Message, MessageDTO>(vkMessage);
        }

        public static IEnumerable<MessageDTO> Map(IEnumerable<VkNet.Model.Message> vkMessages)
        {
            return vkMessages.Select(Map).ToList();
        }

        public static MessageDTO Map(TeleSharp.TL.TLAbsMessage message)
        {
            var tlMessage = message as TeleSharp.TL.TLMessage;
            Mapper.Initialize(cfg => cfg.CreateMap<TeleSharp.TL.TLMessage, MessageDTO>()
                .ForMember("AccountId", x => x.MapFrom(c => c.from_id)));
            return Mapper.Map<TeleSharp.TL.TLAbsMessage, MessageDTO>(tlMessage);
        }

        public static IEnumerable<MessageDTO> Map(IEnumerable<TeleSharp.TL.TLAbsMessage> tlMesEnumerable)
        {
            return tlMesEnumerable.Select(Map).ToList();
        }
    }
}
