using System.Collections.Generic;
using System.Web.Http;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;

namespace Dialog.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/contact")]
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

        [Route("{id:int}")]
        [HttpPut]
        public void Update(ContactDto item)
        {
            _contactsService.Update(item);
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(ContactDto item)
        {
            _contactsService.Delete(item);
        }
    }
}