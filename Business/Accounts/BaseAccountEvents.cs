using System;
using DTOs;

namespace Business.Accounts
{
    public abstract class BaseAccountEvents
    {
        public void MessageRecivedHandler(MessageDTO message)
        {
            OnMessageRecived?.Invoke(message);
        }
        public delegate void MessageRecived(MessageDTO message);
        public event MessageRecived OnMessageRecived;

        public void ContactAddedHandler(ContactDTO contact)
        {
            OnContactAdded?.Invoke(contact);
        }
        public delegate void ContactAdded(ContactDTO contact);
        public event ContactAdded OnContactAdded;

        public string CaptchaNeededHandler(Uri captchaUrl, long sid)
        {
            return OnCaptchaNeeded?.Invoke(captchaUrl, sid);
        }
        public delegate string CaptchaNeeded(Uri captchaUrl, long sid);
        public event CaptchaNeeded OnCaptchaNeeded;

        public string CodeNeededHandler()
        {
            return OnCodeNeeded?.Invoke();
        }
        public delegate string CodeNeeded();
        public event CodeNeeded OnCodeNeeded;

        public void AccountUpdatedHandler(AccountDTO account)
        {
            OnAccountUpdated?.Invoke(account);
        }
        public delegate void AccountUpdated(AccountDTO account);
        public event AccountUpdated OnAccountUpdated;
    }
}
