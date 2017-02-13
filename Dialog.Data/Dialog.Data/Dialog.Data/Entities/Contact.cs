using Olga.Data.Entities;

namespace Dialog.Data.Entities
{
    public class Contact : Entity
    {
        public int AccountId { get; set; }
        public string Name { get; set; }

        public int? MetaContactId { get; set; }
    }
}
