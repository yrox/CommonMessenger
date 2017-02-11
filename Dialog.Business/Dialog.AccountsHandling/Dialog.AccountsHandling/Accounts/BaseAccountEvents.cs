using System;
using System.Collections.Generic;
using Dialog.DTOs;

namespace Dialog.AccountsHandling.Accounts
{
    public abstract class BaseAccountEvents
    {
        public delegate void AccountUpdated(AccountDTO account);

        public delegate string CaptchaNeeded(Uri captchaUrl, long sid);

        public delegate string CodeNeeded();

        public delegate void ContactAdded(ContactDTO contact);

        public delegate void MessageRecived(MessageDTO message);

        public void MessageRecivedHandler(IEnumerable<MessageDTO> messages)
        {
            if (OnMessageRecived == null) return;
            foreach (var message in messages)
            {
                OnMessageRecived.Invoke(message);
            }
        }

        public void MessageRecivedHandler(MessageDTO message)
        {
            OnMessageRecived?.Invoke(message);
        }

        public event MessageRecived OnMessageRecived;

        public void ContactAddedHandler(ContactDTO contact)
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

        public void AccountUpdatedHandler(AccountDTO account)
        {
            OnAccountUpdated?.Invoke(account);
        }

        public event AccountUpdated OnAccountUpdated;
    }
}
