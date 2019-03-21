using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using JsonApiDotNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MindMeldApi.Data;
using MindMeldApi.Data.Entities;
using MindMeldApi.Data.Queries;
using MindMeldApi.Data.QueryTypes;
using Newtonsoft.Json;

namespace MindMeldApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonFormatters(options =>
            {
                options.Formatting = Formatting.Indented;
                options.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<IDocumentWriter, DocumentWriter>();

            services.AddScoped<BookQuery>();
            services.AddScoped<BookType>();
            services.AddScoped<AuthorType>();
            services.AddScoped<PublisherType>();

            services.AddScoped<ISchema, BookSchema>();

            services.AddScoped<MindMeldRepository>();

            services.AddDbContext<MindMeldDbContext>(opts => opts.UseInMemoryDatabase("MINDMELDPROD"));

            services.AddJsonApi(options =>
            {
                options.Namespace = "jsonapi";
                options.DefaultPageSize = 5;
                options.IncludeTotalRecordCount = true;
                options.SerializerSettings.Formatting = Formatting.Indented;
            },
            mvcBuilder,
                discovery => discovery.AddCurrentAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Seed the database.
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MindMeldDbContext>();
                context.AddRange(new List<Book>
                {
                    new Book{Id = 1, AuthorId = 1, PublisherId = 1, Title="How to live code a demo", PublishDate = DateTime.Parse("1/1/2001")},
                    new Book{Id = 2, AuthorId = 2, PublisherId = 2, Title="How sausages are made", PublishDate = DateTime.Parse("2/2/2002")},
                    new Book{Id = 3, AuthorId = 3, PublisherId = 3, Title="Why the internet is magic", PublishDate = DateTime.Parse("3/3/2003")},
                    new Book{Id = 4, AuthorId = 4, PublisherId = 2, Title="Cookies, cookies, and more cookies", PublishDate = DateTime.Parse("4/4/2004")},
                    new Book{Id = 5, AuthorId = 1, PublisherId = 1, Title="Mystery!", PublishDate = DateTime.Parse("5/5/2005")},
                    new Book{Id = 6, AuthorId = 4, PublisherId = 1, Title="Make money selling cookies!", PublishDate = DateTime.Parse("6/6/2006")},
                    new Book{Id = 7, AuthorId = 1, PublisherId = 1, Title="Yes, no, maybe?", PublishDate = DateTime.Parse("7/7/2007")}
                });

                context.AddRange(new List<Author>
                {
                    new Author{Id = 1, Birthdate = DateTime.Parse("1/1/1980"), Name = "John Jakob"},
                    new Author{Id = 2, Birthdate = DateTime.Parse("2/2/1996"), Name = "Phil Portabella"},
                    new Author{Id = 3, Birthdate = DateTime.Parse("3/3/1968"), Name = "Henry Smalls"},
                    new Author{Id = 4, Birthdate = DateTime.Parse("4/4/1910"), Name = "Super Old Guy"},
                });

                context.AddRange(new List<Publisher>
                {
                    new Publisher{Id = 1, Name ="Big Books Publishing"},
                    new Publisher{Id = 2, Name ="Medium Books Publishing"},
                    new Publisher{Id = 3, Name ="Small Books Publishing"}
                });

                context.SaveChanges();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseGraphQL();
        }
    }
}
