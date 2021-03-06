﻿using System.Web.Http;
using Olga.Data.Interfaces;

namespace WebApi.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        //protected BaseController() { }
        protected IUnitOfWork UnitOfWork { get; set; }
    }
}
