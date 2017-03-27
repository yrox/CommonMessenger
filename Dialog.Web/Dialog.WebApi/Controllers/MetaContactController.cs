using System.Collections.Generic;
using System.Web.Http;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;

namespace Dialog.WebApi.Controllers
{
    //[Authorize]
    [RoutePrefix("api/metacontact")]
    public class MetaContactController : ApiController
    {
        private readonly IMetaContactsService _metaContactsService;

        public MetaContactController(IMetaContactsService service)
        {
            _metaContactsService = service;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<MetaContactDto> GetAll()
        {
            return _metaContactsService.GetAll();
        }

        [Route("{id:int}")]
        [HttpGet]
        public MetaContactDto Get(int id)
        {
            return _metaContactsService.Find(id);
        }

        [Route("")]
        [HttpPost]
        public void Insert(MetaContactDto item)
        {
            _metaContactsService.Insert(item);
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Update(MetaContactDto item)
        {
            _metaContactsService.Update(item);
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(MetaContactDto item)
        {
            _metaContactsService.Delete(item);
        }
    }
}