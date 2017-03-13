using System.Collections.Generic;
using System.Web.Http;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;

namespace Dialog.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/messages")]
    public class MessagesController : ApiController
    {
        private readonly IMessagesService _messagesService;

        public MessagesController(IMessagesService service)
        {
            _messagesService = service;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<MessageDto> GetAll()
        {
            return _messagesService.GetAll();
        }

        [Route("{id:int}")]
        [HttpGet]
        public MessageDto Get(int id)
        {
            return _messagesService.Find(id);
        }

        [Route("")]
        [HttpPost]
        public void Insert(MessageDto item)
        {
            _messagesService.Insert(item);
        }

        [Route("send")]
        [HttpPost]
        public void Send(MessageDto item, string username)
        {
           _messagesService.Send(item, username);
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Update(MessageDto item)
        {
            _messagesService.Update(item);
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(MessageDto item)
        {
            _messagesService.Delete(item);
        }
    }
}