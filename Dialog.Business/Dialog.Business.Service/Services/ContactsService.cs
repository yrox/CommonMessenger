using System.Collections.Generic;
using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;
using Dialog.Data.Entities;
using Dialog.Data.Interfaces;

namespace Dialog.Business.Service.Services
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

        public IEnumerable<ContactDto> GetAll()
        {
            return _dialogUnitOfWork.ContactsRepository.GetAll<ContactDto>();
        }

        public ContactDto Find(int id)
        {
            return _mapper.Map<ContactDto>(_dialogUnitOfWork.ContactsRepository.Find(id));
        }

        public void Insert(ContactDto entity)
        {
            _dialogUnitOfWork.ContactsRepository.Insert(_mapper.Map<Contact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Update(ContactDto entity)
        {
            _dialogUnitOfWork.ContactsRepository.Update(_mapper.Map<Contact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Delete(ContactDto entity)
        {
            _dialogUnitOfWork.ContactsRepository.Delete(_mapper.Map<Contact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }
    }
}