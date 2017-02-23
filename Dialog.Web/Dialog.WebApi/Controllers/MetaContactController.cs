using System.Collections.Generic;
using System.Web.Http;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;

namespace Dialog.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/metacontacts")]
    public class MetaContactController : ApiController
    {
        private readonly IMetaContactsService _metaContactsService;

        public MetaContactController(IMetaContactsService service)
        {
            _metaContactsService = service;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<MetaContactDTO> GetAll()
        {
            return _metaContactsService.GetAll();
        }

        [Route("{id:int}")]
        [HttpGet]
        public MetaContactDTO Get(int id)
        {
            return _metaContactsService.Find(id);
        }

        [Route("")]
        [HttpPost]
        public void Insert(MetaContactDTO item)
        {
            _metaContactsService.Insert(item);
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Update(MetaContactDTO item)
        {
            _metaContactsService.Update(item);
        }

        [Route("del")]
        [HttpDelete]
        public void Delete(MetaContactDTO item)
        {
            _metaContactsService.Delete(item);
        }
    }
}