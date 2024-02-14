using AutoMapper;
using AutoMapper.Extensions.EnumMapping;

using Chat.DataAccess.Entities;
using Chat.ApplicationServices.Domain.User.Add;

namespace Chat.ApplicationServices.Domain.User
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<AddUserRequest, UserEntity>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username));

            CreateMap<UserEntity, UserModel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.Age));
            //.ForMember(x => x.Password, y => y.MapFrom(z => z.Password));

            CreateMap<UserEntity, UserModel>()
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role));

            //CreateMap<DbRole, DomainRole>()
            //    .ConvertUsingEnumMapping(x => x.MapValue(DbRole, DomainRole));

        }
    }
}
