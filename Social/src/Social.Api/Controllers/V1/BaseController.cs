using Azure;
using Microsoft.AspNetCore.Mvc;
using Social.Api.Contracts.Common;
using Social.Application.Enums;
using Social.Application.Models;

namespace Social.Api.Controllers.V1
{
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleErrorResponse(List<Error> errors)
        {
            if (errors.Any(e => e.Code == ErrorCode.NotFound))
            {
                var error = errors.FirstOrDefault(e => e.Code == ErrorCode.NotFound);
                var apiError = new ErrorResponse
                {
                    StatusCode = 404,
                    StatusPhrase = "Not Found",
                    Timestamp = DateTime.UtcNow,
                    Errors = new List<string> { error.Message }
                };
                return NotFound(apiError);
            }

            var serverError = errors.FirstOrDefault(e => e.Code == ErrorCode.ServerError);
            var serverApiError = new ErrorResponse
            {
                StatusCode = 500,
                StatusPhrase = "Internal server error",
                Timestamp = DateTime.UtcNow,
                Errors = new List<string> { "Unknown error" }
            };
            return StatusCode(500, serverApiError);
        }
    }
}
