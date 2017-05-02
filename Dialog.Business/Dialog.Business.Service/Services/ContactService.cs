using System.Collections.Generic;
using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;
using Dialog.Data.Entities;
using Dialog.Data.Interfaces;

namespace Dialog.Business.Service.Services
{
    public class ContactService : IContactsService
    {
        private readonly IDialogUnitOfWork _dialogUnitOfWork;
        private readonly IMapper _mapper;

        public ContactService(IDialogUnitOfWork unitOfWork, IMapper mapper)
        {
            _dialogUnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<ContactDto> GetAll()
        {
            return _mapper.Map<IEnumerable<ContactDto>>(_dialogUnitOfWork.ContactsRepository.GetAll());
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

        public void Delete(int id)
        {
            var entity = Find(id);
            _dialogUnitOfWork.ContactsRepository.Delete(_mapper.Map<Contact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }
    }
}