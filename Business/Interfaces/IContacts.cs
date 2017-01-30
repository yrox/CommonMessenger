using System.Collections.Generic;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IContacts
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetContact(long id);
        Contact GetContact(string nameOrPhoneNumber);
        void NewContactAdded(Contact contact);
    }
}
