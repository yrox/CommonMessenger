using System.Collections.Generic;

namespace Dialog.Business.DTO
{
    public class MetaContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ContactDto> Contacts { get; set; }
        public IEnumerable<MessageDto> Messages { get; set; }
        public UserDto User { get; set; }
    }
}
