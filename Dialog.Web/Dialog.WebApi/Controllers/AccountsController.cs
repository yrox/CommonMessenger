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
        private readonly IAccountsService _accountsAccService;
        private readonly IUsersService _usersService;

        public AccountsController(IAccountsService accService, IUsersService usersService)
        {
            _accountsAccService = accService;
            _usersService = usersService;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<AccountDTO> Get()
        {
            var userId = _usersService.GetByName(User.Identity.Name).Id;
            return _accountsAccService.GetAllByUserId(userId);
        }

        [Route("{id:int}")]
        [HttpGet]
        public AccountDTO Get(int id)
        {
            return _accountsAccService.Find(id);
        }

        [Route("")]
        [HttpPost]
        public void Insert(AccountDTO item)
        {
            var userId = _usersService.GetByName(User.Identity.Name).Id;
            item.User.Id = userId;
            _accountsAccService.Insert(item);
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Update(AccountDTO item)
        {
            var userId = _usersService.GetByName(User.Identity.Name).Id;
            item.User.Id = userId;
            _accountsAccService.Update(item);
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(AccountDTO item)
        {
            _accountsAccService.Delete(item);
        }
    }
}