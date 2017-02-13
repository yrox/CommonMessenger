using Autofac;
using Dialog.Data;
using Dialog.Data.EntityFramewrk;
using Dialog.Data.Interfaces;

namespace Dialog.Services.Util
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DialogUnitOfWork>().As<IDialogUnitOfWork>()
                .WithParameter("context", "DialogDb");
            base.Load(builder);
        }
    }
}
