using System.Web.Http;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;

namespace Dialog.WebApi.Controllers
{
    //[Authorize]
    [RoutePrefix("api/notification")]
    public class NotificationController : ApiController
    {
        private readonly INotificationsService _service;

        public NotificationController(INotificationsService service)
        {
            _service = service;
        }

        [Route("sendmessage")]
        [HttpPost]
        public void SendMessageRecived(string userName, MessageDto item)
        {
            _service.SendMessage(item, userName);
        }

        [Route("{name:minlength(4)}/start")]
        [HttpGet]
        public void StartListening(string name)
        {
            _service.CreateUserNotificator(name);
        }
    }
}
