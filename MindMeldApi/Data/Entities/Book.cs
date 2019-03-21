using JsonApiDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi.Data.Entities
{
    public class Book : Identifiable
    {
        [Attr("title")]
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        [Attr("publishdate")]
        public DateTime PublishDate { get; set; }

        [HasOne("author")]
        public Author Author { get; set; }
        [HasOne("publisher")]
        public Publisher Publisher { get; set; }

    }
}
