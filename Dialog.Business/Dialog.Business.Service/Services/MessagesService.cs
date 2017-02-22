using System.Collections.Generic;
using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;
using Dialog.Data.Entities;
using Dialog.Data.Interfaces;

namespace Dialog.Business.Service.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly IDialogUnitOfWork _dialogUnitOfWork;
        private readonly IMapper _mapper;
        private readonly INotificationsService _notifications;

        public MessagesService(IDialogUnitOfWork unitOfWork, IMapper mapper, INotificationsService service)
        {
            _dialogUnitOfWork = unitOfWork;
            _mapper = mapper;
            _notifications = service;
        }

        public IEnumerable<MessageDTO> GetAll()
        {
            return _dialogUnitOfWork.MessagesRepository.GetAll<MessageDTO>();
        }

        public MessageDTO Find(int id)
        {
            return _mapper.Map<MessageDTO>(_dialogUnitOfWork.MessagesRepository.Find(id));
        }

        public void Insert(MessageDTO entity)
        {
            _dialogUnitOfWork.MessagesRepository.Insert(_mapper.Map<Message>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Update(MessageDTO entity)
        {
            _dialogUnitOfWork.MessagesRepository.Update(_mapper.Map<Message>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Delete(MessageDTO entity)
        {
            _dialogUnitOfWork.MessagesRepository.Delete(_mapper.Map<Message>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Send(MessageDTO message, string userName)
        {
            Insert(message);
            _notifications.SendMessage(message, userName);
        }
    }
}