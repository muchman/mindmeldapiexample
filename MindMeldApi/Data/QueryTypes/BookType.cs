using GraphQL.Types;
using MindMeldApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi.Data.QueryTypes
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(x => x.Id).Description("The id of the book.");
            Field(x => x.Title).Description("The title of the book.");
            Field<AuthorType>("author");
            Field<PublisherType>("publisher");

        }
    }
}
