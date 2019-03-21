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
        public JsonResult Get()
        {
            return new JsonResult(new ControllerResult<IEnumerable<Book>>(_repository.GetAll<Book>()));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(new ControllerResult<Book>(_repository.GetById<Book>(id)));
        }

        [HttpGet("{id}/Author")]
        public JsonResult GetWithAuthor(int id)
        {
            var book = _repository.GetById<Book>(id);
            book.Author = _repository.GetById<Author>(book.AuthorId);
            return new JsonResult(new ControllerResult<Book>(book));
        }

        [HttpGet("{id}/Publisher")]
        public JsonResult GetWithPublisher(int id)
        {
            var book = _repository.GetById<Book>(id);
            book.Publisher = _repository.GetById<Publisher>(book.PublisherId);
            return new JsonResult(new ControllerResult<Book>(book));
        }

        [HttpGet("{id}/Author/Publisher")]
        public JsonResult GetWithAuthorAndPublisher(int id)
        {
            var book = _repository.GetById<Book>(id);
            book.Author = _repository.GetById<Author>(book.AuthorId);
            book.Publisher = _repository.GetById<Publisher>(book.PublisherId);
            return new JsonResult(new ControllerResult<Book>(book));
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
