using System;
using System.Collections.Generic;
using DTOs;

namespace Business.Interfaces
{
    public interface IAccount
    { 
        void Authorize(string code);
        void Authorize(string captcha, long sid);

        IEnumerable<ContactDTO> GetAllContacts();

        void SendMessage(MessageDTO message);
        void SendMessage(MessageDTO message, string captcha, long sid);

        event EventHandler OnMessageRecived;
        event EventHandler OnContactAdded;
        event EventHandler OnCaptchaNeeded;
        event EventHandler OnAccountUpdated;

    }
}
