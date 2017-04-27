using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dialog.Business.Accounts;
using Dialog.Business.DTO;
using Dialog.Busness.Notifications.Interfaces;
using Dialog.Busness.Notifications.Util;

namespace Dialog.Busness.Notifications.Handlers
{
    public class SignalrNotificationHandler : INotificationHandler
    {
        public SignalrNotificationHandler(IMapper mapper, IEnumerable<AccountDto> accs, ConnectionMapping<string> connections, string userName)
        {
            var accountsManager = new AccountsGroup(accs.First(), mapper);
            BusinessNotificationHandler = new BusinessNotificationHadler(accountsManager, userName);
            UserNotificationHandler = new SignalrUserNotificationHandler(accountsManager, connections, userName);
        }

        public IBusinessNotificationHandler BusinessNotificationHandler { get; }

        public IUserNotificationHandler UserNotificationHandler { get; }

    }
}
