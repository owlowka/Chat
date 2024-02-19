
using AutoMapper;

using Chat.ApplicationServices.Domain.Message;
using Chat.ApplicationServices.Domain.Message.Add;
using Chat.DataAccess.Entities;

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
