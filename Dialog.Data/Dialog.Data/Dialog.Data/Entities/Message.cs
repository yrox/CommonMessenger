using Olga.Data.Entities;

namespace Dialog.Data.Entities
{
    public class Message : Entity
    {
        public int AccountId { get; set; }
        public int MetaContactId { get; set; }
        public string Text { get; set; }
    }
}
