using System.Collections.Generic;

namespace Dialog.Business.DTO
{
    public class MetaContactDTO
    {
        public int Id { get; set; }
        public IEnumerable<ContactDTO> Contacts { get; set; }
    }
}
