using System.Collections.Generic;
using Olga.Data;

namespace Data.Business.Entities
{
    public class MetaContact : Entity
    {
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
