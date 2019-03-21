using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MindMeldApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        public ContentResult Get()
        {
            var baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            var rest1 = baseUrl + "/rest/book";
            var rest2 = baseUrl + "/rest/book/1";
            var rest3 = baseUrl + "/rest/author";
            var rest4 = baseUrl + "/rest/author/1";
            var rest5 = baseUrl + "/rest/publisher";
            var rest6 = baseUrl + "/rest/publisher/1";
            var rest7 = baseUrl + "/rest/book/1/author";
            var rest8 = baseUrl + "/rest/book/1/publisher";
            var rest9 = baseUrl + "/rest/book/1/author/publisher";

            var json1 = baseUrl + "/jsonapi/books";
            var json2 = baseUrl + "/jsonapi/books/1";
            var json3 = baseUrl + "/jsonapi/authors";
            var json4 = baseUrl + "/jsonapi/authors/1";
            var json5 = baseUrl + "/jsonapi/publishers";
            var json6 = baseUrl + "/jsonapi/publishers/1";
            var json7 = baseUrl + "/jsonapi/authors/1?include=books";
            var json8 = baseUrl + "/jsonapi/books?filter%5Btitle%5D=Mystery!";
            var json9 = baseUrl + "/jsonapi/books?filter%5Btitle%5D=like:Cookies";
            var json10 = baseUrl + "/jsonapi/authors?sort=birthdate";
            var json11 = baseUrl + "/jsonapi/books?page%5Bnumber%5D=1&page%5Bsize%5D=1";
            var json12 = baseUrl + "/jsonapi/authors/1?fields%5Bauthors%5D=name";

            var graph1 = baseUrl + @"/graphql?query={books{id%20title}}";
            var graph2 = baseUrl + @"/graphql?query={book(id:1){id%20title}}";
            var graph3 = baseUrl + @"/graphql?query={authors{id%20name}}";
            var graph4 = baseUrl + @"/graphql?query={author(id:1){id%20name}}";
            var graph5 = baseUrl + @"/graphql?query={publishers{id%20name}}";
            var graph6 = baseUrl + @"/graphql?query={publisher(id:1){id%20name}}";
            var graph7 = baseUrl + @"/graphql?query={books{id%20title%20author{name}%20publisher{name}}}";





            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = $@"<html><body><h1>SUPER AWESOME MIND MELD DEMO</h1>
<h2>REST</h2>
<ul>
<li><a href={rest1}>{Clean(rest1)}</a></li>
<li><a href={rest2}>{Clean(rest2)}</a></li>
<li><a href={rest3}>{Clean(rest3)}</a></li>
<li><a href={rest4}>{Clean(rest4)}</a></li>
<li><a href={rest5}>{Clean(rest5)}</a></li>
<li><a href={rest6}>{Clean(rest6)}</a></li>
<li><a href={rest7}>{Clean(rest7)}</a></li>
<li><a href={rest8}>{Clean(rest8)}</a></li>
<li><a href={rest9}>{Clean(rest9)}</a></li>
</ul>                           

<h2>JSON:API</h2>
<ul>
<li><a href={json1}>{Clean(json1)}</a></li>
<li><a href={json2}>{Clean(json2)}</a></li>
<li><a href={json3}>{Clean(json3)}</a></li>
<li><a href={json4}>{Clean(json4)}</a></li>
<li><a href={json5}>{Clean(json5)}</a></li>
<li><a href={json6}>{Clean(json6)}</a></li>
<li><a href={json7}>{Clean(json7)}</a></li>
<li><a href={json8}>{Clean(json8)}</a></li>
<li><a href={json9}>{Clean(json9)}</a></li>
<li><a href={json10}>{Clean(json10)}</a></li>
<li><a href={json11}>{Clean(json11)}</a></li>
<li><a href={json12}>{Clean(json12)}</a></li>
</ul>

<h2>GraphQL</h2>
<ul>
<li><a href={graph1}>{Clean(graph1)}</a></li>
<li><a href={graph2}>{Clean(graph2)}</a></li>
<li><a href={graph3}>{Clean(graph3)}</a></li>
<li><a href={graph4}>{Clean(graph4)}</a></li>
<li><a href={graph5}>{Clean(graph5)}</a></li>
<li><a href={graph6}>{Clean(graph6)}</a></li>
<li><a href={graph7}>{Clean(graph7)}</a></li>
</ul>                    


</body></html>"
            };
        }

        private string Clean(string s)
        {
            return s.Replace("%20", " ").Replace("%5B", "[").Replace("%5D", "]");
        }
    }
}