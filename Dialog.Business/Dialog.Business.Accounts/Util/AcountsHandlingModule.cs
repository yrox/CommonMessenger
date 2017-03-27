using Autofac;
using AutoMapper;
using Dialog.Business.Accounts.Util.MapperProfiles;

namespace Dialog.Business.Accounts.Util
{
    public class AcountsHandlingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<VkAccount>().As<IAccount>();
            //builder.Register(x => new MapperConfiguration(
            //    cfg =>
            //    {
            //        cfg.AddProfile(typeof(AccContactProfile));
            //        cfg.AddProfile(typeof(AccMessageProfile));
            //    }));
        }
    }
}
