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
    public class UpdateUserCommandHanlder : IRequestHandler<UpdateUserCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _dataContext;
        public UpdateUserCommandHanlder(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<OperationResult<UserProfile>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();
            try
            {
                var userProfile = await _dataContext.UserProfiles.FirstOrDefaultAsync(x => x.UserProfileId == request.UserProfileId);
                if(userProfile is null)
                {
                    result.IsError = true;
                    var error = new Error { Code = ErrorCode.NotFound, Message = $"No UserProfile found with ID {request.UserProfileId}" };
                    result.Errors.Add(error);
                    return result;
                }

                var basicInfo = BasicInfo.Create(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);
               
                userProfile!.UpdateBasicInfo(basicInfo);
                _dataContext.UserProfiles.Update(userProfile);
                await _dataContext.SaveChangesAsync();

                result.Payload = userProfile;
            }
            catch (Exception ex)
            {
                result.IsError = true;
                var error = new Error { Code = ErrorCode.ServerError, Message = ex.Message };
                result.Errors.Add(error);
            }
            return result;
        }
    }
}
