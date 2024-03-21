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
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfiles, IEnumerable<UserProfile>>
    {
        private readonly DataContext _dataContext;

        public GetAllUserProfilesQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfiles request, CancellationToken cancellationToken)
        {
            return await _dataContext.UserProfiles.ToListAsync(cancellationToken);
        }
    }
}
