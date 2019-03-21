using JsonApiDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi.Data.Entities
{
    public class Publisher : Identifiable
    {
        [Attr("name")]
        public string Name { get; set; }
        [HasMany("books")]
        public ICollection<Book> Books { get; set; }
    }
}
