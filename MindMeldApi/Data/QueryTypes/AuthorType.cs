using GraphQL.Types;
using MindMeldApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi.Data.QueryTypes
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(MindMeldRepository repository)
        {
            Field(x => x.Id).Description("The Id of the person.");
            Field(x => x.Name).Description("The name of the person.");
            Field(x => x.Birthdate).Description("The birthdate of the person.");
            Field<ListGraphType<BookType>>("books",
                resolve: context => repository.GetBooksByAuthor(context.Source));
        }
    }
}
