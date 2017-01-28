using System.Collections.Generic;
using System.Web.Http;
using Data.Entities;
using Olga.Data.Interfaces;
using WebApi.Hubs;

namespace WebApi.Controllers
{
    public class ContactsControllerWithHub : BaseControllerWithHub<ContactsНub>
    {
        public ContactsControllerWithHub(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        // GET: api/Contacts
        [HttpGet]
        public IEnumerable<Contact> Get()//TODO: GetAll
        {
            return new List<Contact>();
        }

        // GET: api/Contacts/5
        [HttpGet]
        public Contact Get(int id)
        {
            return UnitOfWork.Repository<Contact>().Find(id);
        }

        // POST: api/Contacts
        [HttpPost]
        public void Insert(Contact item)
        {
            UnitOfWork.Repository<Contact>().Insert(item);
            Hub.Clients.All.NewContactAdded(item);
        }

        // PUT: api/Contacts/5
        [HttpPut]
        public void Update(Contact item)
        {
            UnitOfWork.Repository<Contact>().Update(item);
        }

        // DELETE: api/Contacts/5
        [HttpDelete]
        public void Delete(Contact item)
        {
            UnitOfWork.Repository<Contact>().Delete(item);
        }
    }
}
