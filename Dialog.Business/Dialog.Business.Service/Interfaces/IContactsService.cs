using System.Collections.Generic;
using Dialog.Business.DTO;

namespace Dialog.Business.Service.Interfaces
{
    public interface IContactsService
    {
        IEnumerable<ContactDto> GetAll();

        ContactDto Find(int id);

        void Insert(ContactDto entity);

        void Update(ContactDto entity);

        void Delete(int id);
    }
}