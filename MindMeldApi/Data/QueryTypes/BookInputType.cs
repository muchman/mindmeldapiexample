using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi.Data.QueryTypes
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Name = "BookInputType";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<IntGraphType>>("id");
        }
    }
}
