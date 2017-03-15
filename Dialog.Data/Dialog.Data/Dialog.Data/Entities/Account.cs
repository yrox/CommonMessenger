using Olga.Data.Entities;

namespace Dialog.Data.Entities
{
    public class Account : Entity
    {
        public int AccountId { get; set; }

        public string AccessToken { get; set; }
        public string LastUpdate { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public int UserId { get; set; }
        public UserReference User { get; set; }
    }
}
