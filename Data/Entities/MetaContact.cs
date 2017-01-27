using System.Collections.Generic;
using Olga.Data;

namespace Data.Entities
{
    public class MetaContact : Entity
    {
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
