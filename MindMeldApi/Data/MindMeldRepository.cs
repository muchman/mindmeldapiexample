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

        public Book BookById(int id)
        {
            return _context.Books.Find(id);
        }

        public List<Book> AllBooks()
        {
            return _context.Books.ToList();
        }
    }
}
