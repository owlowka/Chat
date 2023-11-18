
using AutoMapper;

namespace Chat.ApplicationServices.Mappings
{
    public class ConversationsProfile : Profile
    {
        public ConversationsProfile()
        {
            CreateMap<DbCoversation, DomainCoversation>()
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
