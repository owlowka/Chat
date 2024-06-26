﻿
using AutoMapper;

using Chat.DataAccess.Entities;
using Chat.Domain.Message.Add;

namespace Chat.Domain.Message
{
    public class MessagesProfile : Profile
    {
        public MessagesProfile()
        {
            //sender, content

            CreateMap<AddMessageRequest, MessageEntity>()
                .ForMember(x => x.CreatedAt, y => y
                    .MapFrom(z => z.CreatedAt))
                .ForMember(x => x.Content, y => y
                    .MapFrom(z => z.Content))
                .ForMember(x => x.Sender, y => y
                    .MapFrom(z => new UserEntity { Username = z.Sender }));

            CreateMap<MessageEntity, MessageModel>()
                .ForMember(x => x.CreatedAt, y => y
                    .MapFrom(z => z.CreatedAt))
                .ForMember(x => x.Content, y => y
                    .MapFrom(z => z.Content))
                .ForMember(x => x.SenderName, y => y
                    .MapFrom(z => z.Sender.Username));


            CreateMap<MessageModel, MessageEntity>()
                .ForMember(x => x.Conversation, y => y
                    .Ignore())
                .ForPath(x => x.Sender.Username, y => y
                    .MapFrom(z => z.SenderName));
        }
    }
}
