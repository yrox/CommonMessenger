using System;
using AutoMapper;

namespace Dialog.WebApi.Util
{
    public class WebMapProfile : Profile
    {
        [Obsolete(
            "Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
        }
    }
}