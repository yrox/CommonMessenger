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

        public IEnumerable<MetaContactDTO> GetAll()
        {
            return _dialogUnitOfWork.MetaContactsRepository.GetAll<MetaContactDTO>();
        }

        public MetaContactDTO Find(int id)
        {
            return _mapper.Map<MetaContactDTO>(_dialogUnitOfWork.MetaContactsRepository.Find(id));
        }

        public void Insert(MetaContactDTO entity)
        {
            _dialogUnitOfWork.MetaContactsRepository.Insert(_mapper.Map<MetaContact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Update(MetaContactDTO entity)
        {
            _dialogUnitOfWork.MetaContactsRepository.Update(_mapper.Map<MetaContact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Delete(MetaContactDTO entity)
        {
            _dialogUnitOfWork.MetaContactsRepository.Delete(_mapper.Map<MetaContact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }
    }
}