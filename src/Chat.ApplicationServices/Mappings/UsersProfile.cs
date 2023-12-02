using AutoMapper;

using Chat.ApplicationServices.API.Domain;

namespace Chat.ApplicationServices.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<AddUserRequest, DbUser>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            CreateMap<DbUser, DomainUser>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.Age))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password));

        }
    }
}
