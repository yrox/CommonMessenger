using System.Collections.Generic;
using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;
using Dialog.Data.Entities;
using Dialog.Data.Interfaces;

namespace Dialog.Business.Service.Services
{
    public class MetaContactsService : IMetaContactsService
    {
        private readonly IDialogUnitOfWork _dialogUnitOfWork;
        private readonly IMapper _mapper;

        public MetaContactsService(IDialogUnitOfWork unitOfWork, IMapper mapper)
        {
            _dialogUnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MetaContactDto> GetAll()
        {
            return _dialogUnitOfWork.MetaContactsRepository.GetAll<MetaContactDto>();
        }

        public MetaContactDto Find(int id)
        {
            return _mapper.Map<MetaContactDto>(_dialogUnitOfWork.MetaContactsRepository.Find(id));
        }

        public void Insert(MetaContactDto entity)
        {
            _dialogUnitOfWork.MetaContactsRepository.Insert(_mapper.Map<MetaContact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Update(MetaContactDto entity)
        {
            _dialogUnitOfWork.MetaContactsRepository.Update(_mapper.Map<MetaContact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Delete(MetaContactDto entity)
        {
            _dialogUnitOfWork.MetaContactsRepository.Delete(_mapper.Map<MetaContact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }
    }
}