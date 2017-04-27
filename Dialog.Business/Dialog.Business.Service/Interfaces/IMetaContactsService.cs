using System.Collections.Generic;
using Dialog.Business.DTO;

namespace Dialog.Business.Service.Interfaces
{
    public interface IMetaContactsService
    {
        IEnumerable<MetaContactDto> GetAll();

        MetaContactDto Find(int id);

        void Insert(MetaContactDto entity);

        void Update(MetaContactDto entity);

        void Delete(int id);
    }
}