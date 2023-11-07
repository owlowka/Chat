using AutoMapper;

using Chat.ApplicationServices.API.Domain.Models;

using DbUser = Chat.DataAccess.Entities.User;

namespace Chat.ApplicationServices.API.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<DbUser, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}
