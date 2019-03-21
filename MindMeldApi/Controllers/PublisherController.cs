using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MindMeldApi.Data;
using MindMeldApi.Data.Entities;

namespace MindMeldApi.Controllers
{
    [Route("rest/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly MindMeldRepository _repository;

        public PublisherController(MindMeldRepository repository)
        {
            this._repository = repository;
        }

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(new ControllerResult<IEnumerable<Publisher>>(_repository.GetAll<Publisher>()));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(new ControllerResult<Publisher>(_repository.GetById<Publisher>(id)));
        }
    }
}
