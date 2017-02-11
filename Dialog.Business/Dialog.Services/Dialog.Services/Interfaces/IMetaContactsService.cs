using System.Collections.Generic;
using Dialog.DTOs;

namespace Dialog.Services.Interfaces
{
    public interface IMetaContactsService 
    {
        IEnumerable<MetaContactDTO> GetAll();

        MetaContactDTO Find(int id);

        void Insert(MetaContactDTO entity);

        void Update(MetaContactDTO entity);

        void Delete(MetaContactDTO entity);
        
    }
}
