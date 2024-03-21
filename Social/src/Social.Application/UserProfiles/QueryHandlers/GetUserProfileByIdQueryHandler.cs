using MediatR;
using Microsoft.EntityFrameworkCore;
using Social.Application.UserProfiles.Queries;
using Social.Domain.Aggregates.UserProfileAggregate;
using Social.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.UserProfiles.QueryHandlers
{
    internal class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileById, UserProfile>
    {
        private readonly DataContext _dataContext;

        public GetUserProfileByIdQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<UserProfile> Handle(GetUserProfileById request, CancellationToken cancellationToken)
        {
            return await _dataContext.UserProfiles.FirstOrDefaultAsync(x=> x.UserProfileId == request.UserProfileId, cancellationToken);
        }
    }
}
