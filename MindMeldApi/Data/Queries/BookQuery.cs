using GraphQL.Types;
using MindMeldApi.Data.Entities;
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
                    return repository.GetById<Book>(context.GetArgument<int>("id"));
                });

            Field<ListGraphType<BookType>>("books",
                resolve: context =>
                {
                    return repository.GetAll<Book>();
                });

            Field<AuthorType>("author",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    return repository.GetById<Author>(context.GetArgument<int>("id"));
                });

            Field<ListGraphType<AuthorType>>("authors",
                resolve: context =>
                {
                    return repository.GetAll<Author>();
                });


            Field<PublisherType>("publisher",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    return repository.GetById<Publisher>(context.GetArgument<int>("id"));
                });

            Field<ListGraphType<PublisherType>>("publishers",
                resolve: context =>
                {
                    return repository.GetAll<Publisher>();
                });


        }
    }
}
