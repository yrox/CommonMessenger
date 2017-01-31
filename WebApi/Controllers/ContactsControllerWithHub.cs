using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Data.Entities;
using DTOs;
using Olga.Data.Interfaces;
using WebApi.Hubs;

namespace WebApi.Controllers
{
    [RoutePrefix("api/contacts")]
    public class ContactsControllerWithHub : BaseControllerWithHub<ContactsНub>
    {
        public ContactsControllerWithHub(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [Route("")]
        [HttpGet]
        public IEnumerable<ContactDTO> Get()//TODO: GetAll
        {
            return new List<ContactDTO>();
        }

        [Route("{id:int}")]
        [HttpGet]
        public ContactDTO Get(int id)
        {
            return Mapper.Map<Contact, ContactDTO>(UnitOfWork.Repository<Contact>().Find(id));
        }

        [Route("")]
        [HttpPost]
        public void Insert(Contact item)
        {
            UnitOfWork.Repository<Contact>().Insert(item);
            Hub.Clients.All.NewContactAdded(item);
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Update(int id, Contact item)
        {
            UnitOfWork.Repository<Contact>().Update(item);
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(Contact item)
        {
            UnitOfWork.Repository<Contact>().Delete(item);
        }
    }
}
