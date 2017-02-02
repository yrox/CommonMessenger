using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Data.Entities;
using DTOs;
using Olga.Data.Interfaces;

namespace WebApi.Controllers
{
    [RoutePrefix("api/metacontacts")]
    public class MetaContactController : BaseController
    {
        //public MetaContactController() { }
        public MetaContactController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [Route("")]
        [HttpGet]
        public IEnumerable<MetaContactDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<MetaContact>, IEnumerable<MetaContactDTO>>(UnitOfWork.Repository<MetaContact>().GetAll());
        }

        [Route("{id:int}")]
        [HttpGet]
        public MetaContactDTO Get(int id)
        {
            return Mapper.Map<MetaContact, MetaContactDTO>(UnitOfWork.Repository<MetaContact>().Find(id));
        }

        [Route("")]
        [HttpPost]
        public void Insert(MetaContactDTO item)
        {
            UnitOfWork.Repository<MetaContact>().Insert(Mapper.Map<MetaContactDTO, MetaContact>(item));
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Update(int id, MetaContactDTO item)
        {
            UnitOfWork.Repository<MetaContact>().Update(Mapper.Map<MetaContactDTO, MetaContact>(item));
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(MetaContactDTO item)
        {
            UnitOfWork.Repository<MetaContact>().Delete(Mapper.Map<MetaContactDTO, MetaContact>(item));
        }

    }
}