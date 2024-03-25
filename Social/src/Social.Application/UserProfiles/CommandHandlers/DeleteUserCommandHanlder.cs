using MediatR;
using Microsoft.EntityFrameworkCore;
using Social.Application.Enums;
using Social.Application.Models;
using Social.Application.UserProfiles.Commands;
using Social.Domain.Aggregates.UserProfileAggregate;
using Social.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.UserProfiles.CommandHandlers
{
    public class DeleteUserCommandHanlder : IRequestHandler<DeleteUserCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _dataContext;
        public DeleteUserCommandHanlder(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<OperationResult<UserProfile>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();
            var userProfile = await _dataContext.UserProfiles.FirstOrDefaultAsync(x => x.UserProfileId == request.UserProfileId);

            if (userProfile is null)
            {
                result.IsError = true;
                var error = new Error { Code = ErrorCode.NotFound, Message = $"No UserProfile found with ID {request.UserProfileId}" };
                result.Errors.Add(error);
                return result;
            }

            _dataContext.UserProfiles.Remove(userProfile!);
            await _dataContext.SaveChangesAsync();

            result.Payload = userProfile;

            return result;
        }
    }
}
