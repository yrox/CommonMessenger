using System.Collections.Generic;
using DTOs;

namespace Business.Interfaces
{
    public interface IContacts
    {
        IEnumerable<ContactDTO> GetAllContacts();
        ContactDTO GetContact(long id);
        ContactDTO GetContact(string nameOrPhoneNumber);
        void NewContactAdded(ContactDTO contact);
    }
}
