using System.Collections.Generic;
using Olga.Data;

namespace Dialog.Data.Entities
{
    public class MetaContact : Entity
    {
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
