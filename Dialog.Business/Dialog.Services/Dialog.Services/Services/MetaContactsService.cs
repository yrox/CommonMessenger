using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dialog.Data.Entities;
using Dialog.Data.Interfaces;
using Dialog.DTOs;
using Dialog.Services.Interfaces;
using Dialog.Services.Util;

namespace Dialog.Services.Services
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
            return _mapper.Map<IEnumerable<MetaContact>, IEnumerable<MetaContactDTO>>(
                    (IEnumerable<MetaContact>)_dialogUnitOfWork.MetaContactsRepository.GetAll());
        }

        public MetaContactDTO Find(int id)
        {
            return _mapper.Map<MetaContact, MetaContactDTO>(_dialogUnitOfWork.MetaContactsRepository.Find(id) as MetaContact);
        }
        
        public void Insert(MetaContactDTO entity)
        {
            _dialogUnitOfWork.MetaContactsRepository.Insert(_mapper.Map<MetaContactDTO, MetaContact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Update(MetaContactDTO entity)
        {
            _dialogUnitOfWork.MetaContactsRepository.Update(_mapper.Map<MetaContactDTO, MetaContact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Delete(MetaContactDTO entity)
        {
            _dialogUnitOfWork.MetaContactsRepository.Delete(_mapper.Map<MetaContactDTO, MetaContact>(entity));
            _dialogUnitOfWork.SaveChanges();
        }
    }
}
