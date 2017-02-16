using System.Collections.Generic;
using Dialog.Business.DTO;

namespace Dialog.Business.Service.Interfaces
{
    public interface IContactsService
    {
        IEnumerable<ContactDTO> GetAll();

        ContactDTO Find(int id);

        void Insert(ContactDTO entity);

        void Update(ContactDTO entity);

        void Delete(ContactDTO entity);
    }
}