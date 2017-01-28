using System.Web.Http;
using Olga.Data.Interfaces;

namespace WebApi.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
