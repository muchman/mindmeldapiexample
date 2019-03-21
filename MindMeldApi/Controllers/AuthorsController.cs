using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using MindMeldApi.Data.Entities;

namespace MindMeldApi.Controllers
{
    public class AuthorsController : JsonApiController<Author>
    {
        public AuthorsController(
            IJsonApiContext jsonApiContext,
            IResourceService<Author> resourceService)
            : base(jsonApiContext, resourceService)
        { }
    }
}