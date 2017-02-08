using Olga.Data;

namespace Data.Business.Entities
{
    public class Message : Entity
    {
        public int AccountId { get; set; }
        public int MetaContactId { get; set; }
    }
}
