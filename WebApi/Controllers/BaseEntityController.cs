using System.Collections.Generic;
using System.Web.Http;
using Olga.Data.Interfaces;

namespace WebApi.Controllers
{
    public abstract class BaseEntityController<T> : BaseController where T : class, IEntity, new()
    {
        protected BaseEntityController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        // GET: api/Contacts
        [HttpGet]
        public IEnumerable<T> GetAll()//TODO GetAll
        {
            return new List<T>();
        }

        // GET: api/Contacts/5
        [HttpGet]
        public T Get(int id)
        {
            return UnitOfWork.Repository<T>().Find(id);
        }

        // POST: api/Contacts
        [HttpPost]
        public void Insert(T item)
        {
            UnitOfWork.Repository<T>().Insert(item);
        }

        // PUT: api/Contacts/5
        [HttpPut]
        public void Update(T item)
        {
            UnitOfWork.Repository<T>().Update(item);
        }

        // DELETE: api/Contacts/5
        [HttpDelete]
        public void Delete(T item)
        {
            UnitOfWork.Repository<T>().Delete(item);
        }
    }
}
