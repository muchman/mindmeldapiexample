using GraphQL;
using GraphQL.Types;
using MindMeldApi.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi.Data
{
    public class BookSchema : Schema
    {
        public BookSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<BookQuery>();
        }
    }
}
