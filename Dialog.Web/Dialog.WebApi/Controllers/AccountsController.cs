using System.Collections.Generic;
using System.Web.Http;
using Dialog.DTOs;
using Dialog.Services.Interfaces;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/accounts")]
    public class AccountsController : ApiController
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService service)
        {
            _accountsService = service;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<AccountDTO> Get()
        {
            return _accountsService.GetAll();
        }

        [Route("{id:int}")]
        [HttpGet]
        public AccountDTO Get(int id)
        {
            return _accountsService.Find(id);
        }

        [Route("")]
        [HttpPost]
        public void Insert(AccountDTO item)
        {
            _accountsService.Insert(item);
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Update(AccountDTO item)
        {
            _accountsService.Update(item);
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(AccountDTO item)
        {
            _accountsService.Delete(item);
        }
    }
}