using System.Collections.Generic;

namespace DTOs
{
    public class MetaContactDTO
    {
        public int Id { get; set; }
        public IEnumerable<ContactDTO> Contacts { get; set; }
    }
}
