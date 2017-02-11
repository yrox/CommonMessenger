using System.Collections.Generic;

namespace Dialog.DTOs
{
    public class MetaContactDTO
    {
        public int Id { get; set; }
        public IEnumerable<ContactDTO> Contacts { get; set; }
    }
}
