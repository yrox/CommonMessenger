using System;
using DTOs;

namespace Business.Accounts
{
    public abstract class BaseAccountEvents
    {
        public delegate void MessageRecived(MessageDTO message);
        public event MessageRecived OnMessageRecived;

        public delegate void ContactAdded(ContactDTO contact);
        public event ContactAdded OnContactAdded;

        event EventHandler OnCaptchaNeeded;

        public delegate void AccountUpdated(AccountDTO account);
        public event AccountUpdated OnAccountUpdated;
    }
}
