﻿using Api.Mapper.MapperActions;
using Api.Models.Attach;
using Api.Models.Comment;
using Api.Models.Post;
using Api.Models.Subscribtion;
using Api.Models.User;
using AutoMapper;
using Common;
using DAL.Entities;

namespace Api.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUserModel, User>()
                //.ForMember(u => u.Id, m => m.MapFrom(s => new Guid()))
                .ForMember(d => d.PasswordHash, m => m.MapFrom(s => HashHelper.GetHash(s.Password)))
                .ForMember(d => d.BirthDate, m => m.MapFrom(s => s.BirthDate.UtcDateTime))
                .ForMember(d => d.RegistrateDate, m => m.MapFrom(s => DateTimeOffset.UtcNow));
            CreateMap<User, UserModel>();
            CreateMap<User, UserAvatarModel>()
                .ForMember(d => d.PostsCount, m => m.MapFrom(s => s.Posts!.Count))
                .ForMember(d => d.SubscribtionsCount, m => m.MapFrom(s => s.Subscribtions!.Count))
                .ForMember(d => d.FollowersCount, m => m.MapFrom(s => s.Followers!.Count))
                .AfterMap<UserAvatarMapperAction>();

            CreateMap<CreatePostRequest, CreatePostModel>();
            CreateMap<CreatePostModel, Post>()
                .ForMember(d => d.PostImages, m => m.MapFrom(s => s.Contents))
                .ForMember(d => d.CreatedDate, m => m.MapFrom(s => DateTimeOffset.UtcNow));
            CreateMap<Post, PostModel>()
                .ForMember(d => d.Contens, m => m.MapFrom(d => d.PostImages))
                .ForMember(d => d.LikesCount, m => m.MapFrom(d => d.Likes!.Count))
                .ForMember(d => d.CommentsCount, m => m.MapFrom(d => d.Comments!.Count));

            CreateMap<Comment, CommentModel>();
            CreateMap<CreateCommentModel, Comment>()
                .ForMember(d => d.CreatedDate, m => m.MapFrom(s => DateTimeOffset.UtcNow));

            CreateMap<SubscribtionModel, Subscribtion>()
                .ForMember(d => d.SubscribeTime, m => m.MapFrom(s => DateTimeOffset.UtcNow))
                .ReverseMap();

            CreateMap<Avatar, AttachModel>();
            CreateMap<PostImage, AttachModel>();
            CreateMap<PostImage, AttachExternalModel>().AfterMap<PostContentMapperAction>();
            CreateMap<MetadataModel, PostImage>();
            CreateMap<MetaLinkModel, PostImage>();
        }
    }
}