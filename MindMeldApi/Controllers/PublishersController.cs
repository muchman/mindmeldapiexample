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
    public class PublishersController : JsonApiController<Publisher>
    {
        public PublishersController(
            IJsonApiContext jsonApiContext,
            IResourceService<Publisher> resourceService)
            : base(jsonApiContext, resourceService)
        { }
    }
}