using System.Collections.Concurrent;
using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;
using Dialog.Busness.Notifications.Handlers;
using Dialog.Busness.Notifications.Interfaces;
using Dialog.Busness.Notifications.Util;

namespace Dialog.Business.Service.Services
{
    public class NotifiationService : INotificationsService
    {
        private readonly IMapper _mapper;
        private readonly IAccountsService _accountsService;
        private readonly ConnectionMapping<string> _connections;

        public NotifiationService(IMapper mapper, IAccountsService accountsService, ConnectionMapping<string> connections)
        {
            _mapper = mapper;
            _accountsService = accountsService;
            _connections = connections;
        }
       
        public static ConcurrentDictionary<string, INotificationHandler> NotificationHandlers
            = new ConcurrentDictionary<string, INotificationHandler>();
  
        public void CreateUserNotificator(string userName)
        {
            var userAccs = _accountsService.GetAllByUserName(userName);
            NotificationHandlers.TryAdd(userName, new SignalrNotificationHandler(_mapper, userAccs, _connections, userName));
        }

        public void SendMessage(MessageDto message, string userName)
        {
            INotificationHandler handler;
            var result = NotificationHandlers.TryGetValue(userName, out handler);
            if (result)
            {
                handler.BusinessNotificationHandler.SendMessage(message);
            }
        }
    }
}
