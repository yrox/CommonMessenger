﻿using System;
using AutoMapper;
using Dialog.DTOs;

namespace Dialog.AccountsHandling.Util.AutoMapperConfig
{
    public class MessageProfile : Profile
    {
        [Obsolete(
           "Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<VkNet.Model.Message, MessageDTO>()
                .ForMember("AccountId", x => x.MapFrom(c => c.UserId))
                .ReverseMap();

            CreateMap<TeleSharp.TL.TLAbsMessage, MessageDTO>()
                .ForMember("AccountId", x => x.MapFrom(c => (c as TeleSharp.TL.TLMessage).from_id))
                .ReverseMap();
        }
    }
}