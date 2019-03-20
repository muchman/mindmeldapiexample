using GraphQL.Types;
using MindMeldApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi.Data.QueryTypes
{
    public class PublisherType : ObjectGraphType<Publisher>
    {
        public PublisherType()
        {
            Field(x => x.Id).Description("The id of the publisher.");
            Field(x => x.Name).Description("The name of the publisher.");
            Field<ListGraphType<BookType>>("books",
                resolve: context => new Book[] { });
        }
    }
}
