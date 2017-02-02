using System.Collections.Generic;
using DTOs;

namespace Business.Interfaces
{
    public interface IContacts
    {
        IEnumerable<ContactDTO> GetAllContacts();
        
        void NewContactAdded(ContactDTO contact);
    }
}
