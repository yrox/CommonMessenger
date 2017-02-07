using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Data.Entities;
using DTOs;
using Olga.Data.Interfaces;
using WebApi.Hubs;

namespace WebApi.Controllers
{
    [RoutePrefix("api/messages")]
    public class MessagesController : BaseController
    {
        public MessagesController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

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
