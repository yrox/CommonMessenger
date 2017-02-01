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
    public class ContactsController : BaseControllerWithHub<ContactsНub>
    {
        public ContactsController() { }
        public ContactsController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [Route("")]
        [HttpGet]
        public IEnumerable<ContactDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactDTO>>(UnitOfWork.Repository<Contact>().GetAll());
        }

        [Route("{id:int}")]
        [HttpGet]
        public ContactDTO Get(int id)
        {
            return Mapper.Map<Contact, ContactDTO>(UnitOfWork.Repository<Contact>().Find(id));
        }

        [Route("")]
        [HttpPost]
        public void Insert(ContactDTO item)
        {
            UnitOfWork.Repository<Contact>().Insert(Mapper.Map<ContactDTO, Contact>(item));
            Hub.Clients.All.NewContactAdded(item);
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Update(int id, ContactDTO item)
        {
            UnitOfWork.Repository<Contact>().Update(Mapper.Map<ContactDTO, Contact>(item));
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(ContactDTO item)
        {
            UnitOfWork.Repository<Contact>().Delete(Mapper.Map<ContactDTO, Contact>(item));
        }
    }
}
