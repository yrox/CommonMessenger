using Dialog.Client.DTO.Interfaces;

namespace Dialog.Client.DTO
{
    public class AccountDto : IManageableResource
    {
        public int Id { get; set; }
        public int AccountId { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

    }
}
