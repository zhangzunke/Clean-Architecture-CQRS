using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [HttpPost("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Problem();
        }
    }
}
