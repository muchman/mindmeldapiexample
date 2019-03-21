using GraphQL.Types;
using MindMeldApi.Data.Entities;
using MindMeldApi.Data.QueryTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi.Data.Queries
{
    public class BooksMutation : ObjectGraphType
    {

        public BooksMutation(MindMeldRepository repository)
        {
            Field<BookType>(
              "createbook",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }
              ),
              resolve: context =>
              {
                  var book = context.GetArgument<Book>("book");
                  return repository.Add(book);
              });

            Field<BookType>(
              "deletebook",
              arguments: new QueryArguments(
                new QueryArgument<IntGraphType> { Name = "id" }
              ),
              resolve: context =>
              {
                  var id = context.GetArgument<int>("id");
                  return repository.Delete<Book>(id);
              });
        }

    }
}
