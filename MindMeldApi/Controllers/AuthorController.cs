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
    public class AuthorController : ControllerBase
    {
        private readonly MindMeldRepository _repository;

        public AuthorController(MindMeldRepository repository)
        {
            this._repository = repository;
        }

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(new ControllerResult<IEnumerable<Author>>(_repository.GetAll<Author>()));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(new ControllerResult<Author>(_repository.GetById<Author>(id)));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
