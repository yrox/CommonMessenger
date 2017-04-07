using System.Web.Http;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;

namespace Dialog.WebApi.Controllers
{
    //TODO handle signalr connection
    //[Authorize]
    [RoutePrefix("api/notifications")]
    public class NotificationController : ApiController
    {
        private readonly INotificationsService _service;

        public NotificationController(INotificationsService service)
        {
            _service = service;
        }

        [Route("messages/new")]
        [HttpPost]
        public void SendMessageRecived(string userName, MessageDto item)
        {
            _service.SendMessage(item, userName);
        }

        [Route("{name:minlength(4)}")]
        [HttpGet]
        public void StartListening(string name)
        {
            _service.CreateUserNotificator(name);
        }
    }
}
