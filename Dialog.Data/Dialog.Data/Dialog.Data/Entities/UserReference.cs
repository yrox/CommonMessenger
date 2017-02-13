using Olga.Data.Entities;

namespace Dialog.Data.Entities
{
    public class UserReference : Entity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
