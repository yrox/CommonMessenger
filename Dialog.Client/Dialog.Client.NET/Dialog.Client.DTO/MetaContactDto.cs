using System.Collections.Generic;
using Dialog.Client.DTO.Interfaces;

namespace Dialog.Client.DTO
{
    public class MetaContactDto : IManageableResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ContactDto> Contacts { get; set; }
        public IEnumerable<MessageDto> Messages { get; set; }
    }
}
