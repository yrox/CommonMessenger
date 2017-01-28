using System.Collections.Generic;
using System.Web.Http;
using Olga.Data.Interfaces;
using WebApi.Hubs;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ContactsControllerWithHub : BaseControllerWithHub<ContactsНub>
    {
        public ContactsControllerWithHub(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        // GET: api/Contacts
        [HttpGet]
        public IEnumerable<ContactModel> Get()//TODO GetAll
        {
            return new List<ContactModel>();
        }

        // GET: api/Contacts/5
        [HttpGet]
        public ContactModel Get(int id)
        {
            return new ContactModel();
        }

        // POST: api/Contacts
        [HttpPost]
        public void Insert([FromBody]string value)
        {
        }

        // PUT: api/Contacts/5
        [HttpPut]
        public void Update(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contacts/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
