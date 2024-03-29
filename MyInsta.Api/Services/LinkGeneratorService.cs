﻿using MyInsta.Api.Models.Attach;
using MyInsta.Api.Models.User;
using MyInsta.DAL.Entities.Attaches;
using MyInsta.DAL.Entities.Users;

namespace MyInsta.Api.Services
{
    public class LinkGeneratorService
    {
        public Func<PostImage, string?>? LinkContentGenerator;
        public Func<User, string?>? LinkAvatarGenerator;

        public void FixAvatar(User s, UserAvatarModel d)
        {
            d.AvatarLink = s.Avatar == null ?
                null : LinkAvatarGenerator?.Invoke(s);
        }

        public void FixContent(PostImage s, AttachExternalModel d)
        {
            d.ContentLink = LinkContentGenerator?.Invoke(s);
        }

    }
}
