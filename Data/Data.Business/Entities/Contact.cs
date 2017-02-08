using Olga.Data;

namespace Data.Business.Entities
{
    public class Contact : Entity
    {
        public int AccountId { get; set; }
        public string Name { get; set; }

        public int? MetaContactId { get; set; }
    }
}
