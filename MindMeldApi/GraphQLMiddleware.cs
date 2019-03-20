using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi
{
    public class GraphQLMiddleware
    {
        private readonly RequestDelegate _next;

        public GraphQLMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ISchema schema, IDocumentExecuter executer)
        {
            if (!IsGraphQLRequest(context))
            {
                await _next(context);
                return;
            }

            await ExecuteAsync(context, schema, executer);
        }

        private bool IsGraphQLRequest(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/graphql");
        }

        private async Task ExecuteAsync(HttpContext context, ISchema schema, IDocumentExecuter executer)
        {
            string query = null;

            if (context.Request.Method == "GET")
            {
                query = context.Request.Query["query"];
            }
            else if (context.Request.Method == "POST")
            {
                using (var sr = new StreamReader(context.Request.Body))
                {
                    query = await sr.ReadToEndAsync();
                }
            }
            var result = await executer.ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query;
            });

            await WriteResult(context, result);
        }

        private async Task WriteResult(HttpContext httpContext, ExecutionResult result)
        {
            var json = new DocumentWriter(indent: true).Write(result);
            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }
    }

    public static class GraphQlMiddlewareExtensions
    {
        public static IApplicationBuilder UseGraphQL(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GraphQLMiddleware>();
        }
    }
}
