using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Social.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        [Route(ApiRoutes.Posts.IdRoute)]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
    }
}
