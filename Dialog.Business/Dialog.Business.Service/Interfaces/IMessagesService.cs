using System.Collections.Generic;
using Dialog.Business.DTO;

namespace Dialog.Business.Service.Interfaces
{
    public interface IMessagesService
    {
        IEnumerable<MessageDto> GetAll();

        MessageDto Find(int id);

        void Insert(MessageDto entity);

        void Update(MessageDto entity);

        void Delete(MessageDto entity);

        void Send(MessageDto entity, string userName);
    }
}