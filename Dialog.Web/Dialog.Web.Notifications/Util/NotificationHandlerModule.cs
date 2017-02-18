using System.Collections.Generic;
using Autofac;
using Dialog.Business.DTO;

namespace Dialog.Web.Notifications.Util
{
    public class NotificationHandlerModule : Module
    {
        private readonly IEnumerable<AccountDTO> _accounts;

        public NotificationHandlerModule(IEnumerable<AccountDTO> accs)
        {
            _accounts = accs;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new AcountsHandlingModule());
      
            //builder.RegisterType<SignalrNotificationHandler>().AsImplementedInterfaces().WithParameter("manager", new AccountsManager(_accounts.First()));
           
        }
    }
}
