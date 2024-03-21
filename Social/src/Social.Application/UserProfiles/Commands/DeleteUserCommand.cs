﻿using MediatR;
using Social.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.UserProfiles.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public Guid UserProfileId { get; set; }
    }
}
