using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MindMeldApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi.Data
{
    public class MindMeldDbContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public MindMeldDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
