using System.Collections.Generic;
using System.Web.Http;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;
using Microsoft.AspNet.Identity;

namespace Dialog.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IAccountsService _accountsAccService;
    
        public AccountController(IAccountsService accService)
        {
            _accountsAccService = accService;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<AccountDto> Get()
        {
            var userId = User.Identity.GetUserId<int>();
            return _accountsAccService.GetAllByUserId(userId);
        }

        [Route("{id:int}")]
        [HttpGet]
        public AccountDto Get(int id)
        {
            return _accountsAccService.Find(id);
        }

        [Route("")]
        [HttpPost]
        public void Insert(AccountDto item)
        {
            var userId = User.Identity.GetUserId<int>();
            item.User.Id = userId;
            _accountsAccService.Insert(item);
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Update(AccountDto item)
        {
            var userId = User.Identity.GetUserId<int>();
            item.User.Id = userId;
            _accountsAccService.Update(item);
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(AccountDto item)
        {
            _accountsAccService.Delete(item);
        }
    }
}