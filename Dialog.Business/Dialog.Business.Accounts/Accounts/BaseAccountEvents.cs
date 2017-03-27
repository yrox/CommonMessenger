using System;
using System.Collections.Generic;
using Dialog.Business.DTO;

namespace Dialog.Business.Accounts.Accounts
{
    public abstract class BaseAccountEvents
    {
        public delegate void AccountUpdated(AccountDto account);

        public delegate string CaptchaNeeded(Uri captchaUrl, long sid);

        public delegate string CodeNeeded();

        public delegate void ContactAdded(ContactDto contact);

        public delegate void MessageRecived(MessageDto message);

        public void MessagesRecivedHandler(IEnumerable<MessageDto> messages)
        {
            if (OnMessageRecived == null) return;
            foreach (var message in messages)
            {
                OnMessageRecived.Invoke(message);
            }
        }

        public void MessageRecivedHandler(MessageDto message)
        {
            OnMessageRecived?.Invoke(message);
        }

        public event MessageRecived OnMessageRecived;

        public void ContactAddedHandler(ContactDto contact)
        {
            OnContactAdded?.Invoke(contact);
        }

        public event ContactAdded OnContactAdded;

        public string CaptchaNeededHandler(Uri captchaUrl, long sid)
        {
            return OnCaptchaNeeded?.Invoke(captchaUrl, sid);
        }

        public event CaptchaNeeded OnCaptchaNeeded;

        public string CodeNeededHandler()
        {
            return OnCodeNeeded?.Invoke();
        }

        public event CodeNeeded OnCodeNeeded;

        public void AccountUpdatedHandler(AccountDto account)
        {
            OnAccountUpdated?.Invoke(account);
        }

        public event AccountUpdated OnAccountUpdated;
    }
}
