using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Social.Api.Contracts.Common;
using Social.Api.Contracts.UserProfile.Requests;
using Social.Api.Contracts.UserProfile.Responses;
using Social.Api.Filters;
using Social.Application.Enums;
using Social.Application.UserProfiles.Commands;
using Social.Application.UserProfiles.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Social.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    public class UserProfilesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserProfilesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserProfiles()
        {
            var query = new GetAllUserProfiles();
            var response = await _mediator.Send(query);
            var profiles = _mapper.Map<List<UserProfileResponse>>(response.Payload);
            return Ok(profiles);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult> CreateUserProfile([FromBody] UserProfileCreateUpdate profile)
        {
            var command = _mapper.Map<CreateUserCommand>(profile);
            var response = await _mediator.Send(command);
            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);
            return CreatedAtAction(nameof(GetUserProfileById), new { id = userProfile.UserProfileId }, userProfile);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileById { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(query);
            if (response.IsError)
            {
                return HandleErrorResponse(response.Errors);
            }
            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);
            return Ok(userProfile);
        }

        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [HttpPatch]
        [ValidateGuid("id")]
        [ValidateModel]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileCreateUpdate userProfileCreateUpdate)
        {
            var command = _mapper.Map<UpdateUserCommand>(userProfileCreateUpdate);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);
            if(response.IsError)
            {
                return HandleErrorResponse(response.Errors);
            }
            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);
            return Ok(userProfile);
        }

        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var command = new DeleteUserCommand { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(command);
            if(response.IsError)
            {
                return HandleErrorResponse(response.Errors);
            }
            return NoContent();
        }
    }
}
