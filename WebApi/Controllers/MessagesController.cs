using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Data.Entities;
using DTOs;
using NotificationHandling.Interfaces;
using Olga.Data.Interfaces;

namespace WebApi.Controllers
{
    [RoutePrefix("api/messages")]
    public class MessagesController : BaseController
    {
        private readonly IBusinessNotificationHandler _messagesHandler;

        public MessagesController(IUnitOfWork unitOfWork, IBusinessNotificationHandler messagesHandler) : base(unitOfWork)
        {
            _messagesHandler = messagesHandler;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<MessageDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Message>, IEnumerable<MessageDTO>>(UnitOfWork.Repository<Message>().GetAll());
        }

        [Route("{id:int}")]
        [HttpGet]
        public MessageDTO Get(int id)
        {
            return Mapper.Map<Message, MessageDTO>(UnitOfWork.Repository<Message>().Find(id));
        }

        [Route("")]
        [HttpPost]
        public void Insert(MessageDTO item)
        {
            UnitOfWork.Repository<Message>().Insert(Mapper.Map<MessageDTO, Message>(item));
        }

        [Route("send")]
        [HttpPost]
        public void Send(MessageDTO item)
        {
            Insert(item);
            _messagesHandler.SendMessage(item);
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Update(MessageDTO item)
        {
            UnitOfWork.Repository<Message>().Update(Mapper.Map<MessageDTO, Message>(item));
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(MessageDTO item)
        {
            UnitOfWork.Repository<Message>().Delete(Mapper.Map<MessageDTO, Message>(item));
        }
    }
}
