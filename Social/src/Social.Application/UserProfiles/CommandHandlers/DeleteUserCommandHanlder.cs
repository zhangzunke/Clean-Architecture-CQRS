using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class DeleteUserCommandHanlder : IRequestHandler<DeleteUserCommand>
    {
        private readonly DataContext _dataContext;
        public DeleteUserCommandHanlder(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _dataContext.UserProfiles.FirstOrDefaultAsync(x => x.UserProfileId == request.UserProfileId);
            _dataContext.UserProfiles.Remove(userProfile!);
            await _dataContext.SaveChangesAsync();
        }
    }
}
