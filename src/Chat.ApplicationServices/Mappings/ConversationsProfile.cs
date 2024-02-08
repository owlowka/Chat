
using AutoMapper;

using Chat.ApplicationServices.API.Domain.Models;
using Chat.DataAccess.Entities;

namespace Chat.ApplicationServices.Mappings
{
    public class ConversationsProfile : Profile
    {
        public ConversationsProfile()
        {
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
