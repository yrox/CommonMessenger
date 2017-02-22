using System.Collections.Generic;
using Dialog.Business.DTO;

namespace Dialog.Business.Service.Interfaces
{
    public interface IMessagesService
    {
        IEnumerable<MessageDTO> GetAll();

        MessageDTO Find(int id);

        void Insert(MessageDTO entity);

        void Update(MessageDTO entity);

        void Delete(MessageDTO entity);

        void Send(MessageDTO entity, string userName);
    }
}