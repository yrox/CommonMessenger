using System.Web.Http;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;

namespace Dialog.WebApi.Controllers
{
    [RoutePrefix("api/notifications")]
    public class NotificationsController : ApiController
    {
        private readonly INotificationsService _service;

        public NotificationsController(INotificationsService service)
        {
            _service = service;
        }

        [Route("message")]
        [HttpPost]
        public void SendMessageRecived(string userName, MessageDTO item)
        {
            _service.SendMessage(item, userName);
        }
    }
}
