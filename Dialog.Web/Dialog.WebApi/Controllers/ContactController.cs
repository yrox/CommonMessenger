using System.Collections.Generic;
using System.Web.Http;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;

//TODO getAll of type, for specfic user 

namespace Dialog.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/contacts")]
    public class ContactController : ApiController
    {
        private readonly IContactsService _contactsService;

        public ContactController(IContactsService service)
        {
            _contactsService = service;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<ContactDto> GetAll()
        {
            return _contactsService.GetAll();
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<ContactDto> GetAllByUserame(string name)
        {
            return _contactsService.GetAll();
        }

        [Route("{id:int}")]
        [HttpGet]
        public ContactDto Get(int id)
        {
            return _contactsService.Find(id);
        }

        [Route("")]
        [HttpPost]
        public void Insert(ContactDto item)
        {
            _contactsService.Insert(item);
        }

        [Route("{item.Id:int}")]
        [HttpPut]
        public void Update(ContactDto item)
        {
            _contactsService.Update(item);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _contactsService.Delete(id);
        }
    }
}