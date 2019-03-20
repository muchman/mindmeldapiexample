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
    public class BookController : ControllerBase
    {
        private readonly MindMeldRepository _repository;

        public BookController(MindMeldRepository repository)
        {
            this._repository = repository;
        }

        // GET api/values
        [HttpGet]
        public ControllerResult<IEnumerable<Book>> Get()
        {
            return new ControllerResult<IEnumerable<Book>>(_repository.GetAll<Book>());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ControllerResult<Book> Get(int id)
        {
            return new ControllerResult<Book>(_repository.GetById<Book>(id));
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
