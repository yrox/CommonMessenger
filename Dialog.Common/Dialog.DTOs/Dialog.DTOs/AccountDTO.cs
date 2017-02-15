﻿namespace Dialog.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }

        public string AccessToken { get; set; }
        public string LastUpdate { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public UserDTO User { get; set; }

    }
}
