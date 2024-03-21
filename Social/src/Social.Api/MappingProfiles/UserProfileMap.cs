using AutoMapper;
using Social.Api.Contracts.UserProfile.Requests;
using Social.Api.Contracts.UserProfile.Responses;
using Social.Application.UserProfiles.Commands;
using Social.Domain.Aggregates.UserProfileAggregate;
using System.Linq.Expressions;

namespace Social.Api.MappingProfiles
{
    public class UserProfileMap : Profile
    {
        public UserProfileMap() 
        {
            CreateMap<UserProfileCreateUpdate, UpdateUserCommand>();
            CreateMap<UserProfileCreateUpdate, CreateUserCommand>();
            CreateMap<UpdateUserCommand, BasicInfo>();
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<BasicInfo, BasicInformation>();
        }    
    }
}
