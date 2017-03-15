using System.Collections.Generic;
using Olga.Data.Entities;

namespace Dialog.Data.Entities
{
    public class MetaContact : Entity
    {
        public string Name { get; set; }
        public virtual IEnumerable<Contact> Contacts { get; set; }
        public virtual IEnumerable<Message> Messages { get; set; }

        public virtual UserReference UserReference { get; set; }
    }
}
