using System.Collections.Generic;
using AutoMapper;
using Dialog.Data.Entities;
using Dialog.Data.Interfaces;
using Dialog.DTOs;
using Dialog.Services.Interfaces;

namespace Dialog.Services.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IDialogUnitOfWork _dialogUnitOfWork;
        private readonly IMapper _mapper;

        public ContactsService(IDialogUnitOfWork unitOfWork, IMapper mapper)
        {
            _dialogUnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<ContactDTO> GetAll()
        {
            return
                _mapper.Map<IEnumerable<ContactDTO>>(_dialogUnitOfWork.ContactsRepository.GetAll());
        }

        public ContactDTO Find(int id)
        {
            return _mapper.Map<ContactDTO>(_dialogUnitOfWork.ContactsRepository.Find(id));
        }

        public void Insert(ContactDTO entity)
        {
            _dialogUnitOfWork.ContactsRepository.Insert(_mapper.Map<Contact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Update(ContactDTO entity)
        {
            _dialogUnitOfWork.ContactsRepository.Update(_mapper.Map<Contact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Delete(ContactDTO entity)
        {
            _dialogUnitOfWork.ContactsRepository.Delete(_mapper.Map<Contact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }
    }
}