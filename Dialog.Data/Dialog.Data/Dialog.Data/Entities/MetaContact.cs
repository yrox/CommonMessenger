using System.Collections.Generic;
using Olga.Data.Entities;

namespace Dialog.Data.Entities
{
    public class MetaContact : Entity
    {
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
