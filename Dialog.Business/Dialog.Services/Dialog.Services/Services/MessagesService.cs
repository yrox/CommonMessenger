using System.Collections.Generic;
using AutoMapper;
using Dialog.Data.Entities;
using Dialog.Data.Interfaces;
using Dialog.DTOs;
using Dialog.Services.Interfaces;

namespace Dialog.Services.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly IDialogUnitOfWork _dialogUnitOfWork;
        private readonly IMapper _mapper;

        public MessagesService(IDialogUnitOfWork unitOfWork, IMapper mapper)
        {
            _dialogUnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MessageDTO> GetAll()
        {
            return
                _mapper.Map<IEnumerable<Message>, IEnumerable<MessageDTO>>(_dialogUnitOfWork.MessagesRepository.GetAll());
        }

        public MessageDTO Find(int id)
        {
            return _mapper.Map<Message, MessageDTO>(_dialogUnitOfWork.MessagesRepository.Find(id));
        }

        public void Insert(MessageDTO entity)
        {
            _dialogUnitOfWork.MessagesRepository.Insert(_mapper.Map<MessageDTO, Message>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Update(MessageDTO entity)
        {
            _dialogUnitOfWork.MessagesRepository.Update(_mapper.Map<MessageDTO, Message>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Delete(MessageDTO entity)
        {
            _dialogUnitOfWork.MessagesRepository.Delete(_mapper.Map<MessageDTO, Message>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Send(MessageDTO entity)
        {
            //TODO somehow reference to notif handlers
        }
    }
}