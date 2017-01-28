using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Olga.Data.Interfaces;

namespace WebApi.Controllers
{
    public abstract class BaseControllerWithHub<THub> : BaseController
        where THub : IHub
    {
        protected BaseControllerWithHub(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        private Lazy<IHubContext> _hub = new Lazy<IHubContext>(
            () => GlobalHost.ConnectionManager.GetHubContext<THub>()
        );

        protected IHubContext Hub
        {
            get { return _hub.Value; }
        }
    }

}