using GraphQL.Types;
using MindMeldApi.Data.QueryTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi.Data.Queries
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(MindMeldRepository repository)
        {
            Field<BookType>("book",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return repository.BookById(id);
                });

            Field<ListGraphType<BookType>>("books",
                resolve: context =>
                {
                    return repository.AllBooks();
                });
        }
    }
}
