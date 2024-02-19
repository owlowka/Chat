﻿
using AutoMapper;

using Chat.DataAccess.Entities;
using Chat.Domain.Conversation.GetAll;

namespace Chat.Domain.Conversation
{
    public class ConversationsProfile : Profile
    {
        public ConversationsProfile()
        {
            CreateMap<GetConversationRequest, ConversationEntity>()
                .ForMember(x => x.Id, y => y
                                .MapFrom(z => z.Id));

            CreateMap<ConversationEntity, ConversationModel>()
                .ForMember(x => x.Id, y => y
                                .MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y
                                .MapFrom(z => z.Name))
                .ForMember(x => x.Messages, y => y
                                .MapFrom(z => z.Messages != null ? z.Messages.Select(x => x.Content) : new List<string>()))
                .ForMember(x => x.Users, y => y
                                .MapFrom(z => z.Users));
        }
    }
}