using System.Collections.Generic;
using Dialog.DTOs;

namespace Dialog.Services.Interfaces
{
    public interface IMessagesService
    {
        IEnumerable<MessageDTO> GetAll();

        MessageDTO Find(int id);

        void Insert(MessageDTO entity);

        void Update(MessageDTO entity);

        void Delete(MessageDTO entity);

        void Send(MessageDTO entity);
    }
}