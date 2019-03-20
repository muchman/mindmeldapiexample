using Microsoft.EntityFrameworkCore;
using MindMeldApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi.Data
{
    public class MindMeldRepository
    {
        private MindMeldDbContext _context { get; set; }

        public MindMeldRepository(MindMeldDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooksByAuthor(Author author)
        {
            return _context.Books.Where(b => b.AuthorId == author.Id).ToList();
        }

        public IEnumerable<Book> GetBooksByPublisher(Publisher publisher)
        {
            return _context.Books.Where(b => b.PublisherId == publisher.Id).ToList();
        }

        public T GetById<T>(object id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }
    }
}
