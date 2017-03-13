namespace Dialog.Business.DTO
{
    public class AccountDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }

        public string AccessToken { get; set; }
        public string LastUpdate { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public UserDto User { get; set; }

    }
}
