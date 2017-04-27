using System.Collections.Generic;
using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;
using Dialog.Data.Entities;
using Dialog.Data.Interfaces;

namespace Dialog.Business.Service.Services
{
    public class MetaContactservice : IMetaContactsService
    {
        private readonly IDialogUnitOfWork _dialogUnitOfWork;
        private readonly IMapper _mapper;

        public MetaContactservice(IDialogUnitOfWork unitOfWork, IMapper mapper)
        {
            _dialogUnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MetaContactDto> GetAll()
        {
            return _mapper.Map<IEnumerable<MetaContactDto>>(_dialogUnitOfWork.MetaContactsRepository.GetAll());
        }

        public MetaContactDto Find(int id)
        {
            var c = _dialogUnitOfWork.MetaContactsRepository.Find(id);
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

        public void Delete(int id)
        {
            var entity = Find(id);
            _dialogUnitOfWork.MetaContactsRepository.Delete(_mapper.Map<MetaContact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }
    }
}