using Olga.Data.Entities;

namespace Dialog.Data.Entities
{
    public class UserReference : Entity
    {
        public int Email { get; set; }
        public string UserName { get; set; }
    }
}
