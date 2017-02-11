using System.Collections.Generic;
using System.Web.Http;
using Dialog.DTOs;
using Dialog.Services.Interfaces;

namespace WebApi.Controllers
{
    [RoutePrefix("api/contacts")]
    public class ContactsController : ApiController
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService service)
        {
            _contactsService = service;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<ContactDTO> GetAll()
        {
            return _contactsService.GetAll();
        }

        [Route("{id:int}")]
        [HttpGet]
        public ContactDTO Get(int id)
        {
            return _contactsService.Find(id);
        }

        [Route("")]
        [HttpPost]
        public void Insert(ContactDTO item)
        {
            _contactsService.Insert(item);
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Update(ContactDTO item)
        {
            _contactsService.Update(item);
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(ContactDTO item)
        {
            _contactsService.Delete(item);
        }
    }
}