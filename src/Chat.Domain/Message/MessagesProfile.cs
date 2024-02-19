
using AutoMapper;

using Chat.DataAccess.Entities;
using Chat.Domain.Message.Add;

namespace Chat.Domain.Message
{
    public class MessagesProfile : Profile
    {
        public MessagesProfile()
        {
            CreateMap<AddMessageRequest, MessageEntity>()
                .ForMember(x => x.CreatedAt, y => y.MapFrom(z => z.CreatedAt))
                .ForMember(x => x.Content, y => y.MapFrom(z => z.Content));

            CreateMap<MessageEntity, MessageModel>()
                .ForMember(x => x.CreatedAt, y => y.MapFrom(z => z.CreatedAt))
                .ForMember(x => x.Content, y => y.MapFrom(z => z.Content));
        }
    }
}
