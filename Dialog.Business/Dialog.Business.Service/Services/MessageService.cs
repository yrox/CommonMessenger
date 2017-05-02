using System.Collections.Generic;
using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;
using Dialog.Data.Entities;
using Dialog.Data.Interfaces;

namespace Dialog.Business.Service.Services
{
    public class MessageService : IMessagesService
    {
        private readonly IDialogUnitOfWork _dialogUnitOfWork;
        private readonly IMapper _mapper;
        private readonly INotificationsService _notifications;

        public MessageService(IDialogUnitOfWork unitOfWork, IMapper mapper, INotificationsService service)
        {
            _dialogUnitOfWork = unitOfWork;
            _mapper = mapper;
            _notifications = service;
        }

        public IEnumerable<MessageDto> GetAll()
        {
            return _mapper.Map<IEnumerable<MessageDto>>(_dialogUnitOfWork.MessagesRepository.GetAll());
        }

        public MessageDto Find(int id)
        {
            return _mapper.Map<MessageDto>(_dialogUnitOfWork.MessagesRepository.Find(id));
        }

        public void Insert(MessageDto entity)
        {
            _dialogUnitOfWork.MessagesRepository.Insert(_mapper.Map<Message>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Update(MessageDto entity)
        {
            _dialogUnitOfWork.MessagesRepository.Update(_mapper.Map<Message>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            _dialogUnitOfWork.MessagesRepository.Delete(_mapper.Map<Message>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Send(MessageDto message, string userName)
        {
            Insert(message);
            _notifications.SendMessage(message, userName);
        }
    }
}