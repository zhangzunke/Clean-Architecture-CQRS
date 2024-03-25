using MediatR;
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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _dataContext;
        public CreateUserCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<OperationResult<UserProfile>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var basicInfo = BasicInfo.Create(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);
            var userProfile = UserProfile.Create(Guid.NewGuid().ToString(), basicInfo);
            _dataContext.UserProfiles.Add(userProfile);
            await _dataContext.SaveChangesAsync();
            return new OperationResult<UserProfile> { Payload = userProfile };
        }
    }
}
