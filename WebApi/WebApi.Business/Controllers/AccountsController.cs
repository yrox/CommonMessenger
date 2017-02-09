using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Data.Identity.Entities;
using DTOs;
using Olga.Data.Interfaces;

namespace WebApi.Controllers
{
    [RoutePrefix("api/accunts")]
    public class AccountsController : BaseController
    {
        public AccountsController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [Route("")]
        [HttpGet]
        public IEnumerable<AccountDTO> Get()
        {
            return Mapper.Map<IEnumerable<Account>, IEnumerable<AccountDTO>>(UnitOfWork.Repository<Account>().GetAll());
        }

        [Route("{id:int}")]
        [HttpGet]
        public AccountDTO Get(int id)
        {
            return Mapper.Map<Account, AccountDTO>(UnitOfWork.Repository<Account>().Find(id));
        }

        [Route("")]
        [HttpPost]
        public void Insert(AccountDTO item)
        {
            UnitOfWork.Repository<Account>().Insert(Mapper.Map<AccountDTO, Account>(item));
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Update(AccountDTO item)
        {
            UnitOfWork.Repository<Account>().Update(Mapper.Map<AccountDTO, Account>(item));
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(AccountDTO item)
        {
            UnitOfWork.Repository<Account>().Delete(Mapper.Map<AccountDTO, Account>(item));
        }
    }
}
