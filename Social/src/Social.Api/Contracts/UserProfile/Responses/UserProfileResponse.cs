﻿namespace Social.Api.Contracts.UserProfile.Responses
{
    public class UserProfileResponse
    {
        public Guid UserProfileId {  get; set; }
        public BasicInformation BasicInfo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
