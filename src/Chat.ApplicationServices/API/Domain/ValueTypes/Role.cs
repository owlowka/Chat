global using DbRole = Chat.DataAccess.Entities.Role;
global using DomainRole = Chat.ApplicationServices.API.Domain.ValueTypes.Role;

namespace Chat.ApplicationServices.API.Domain.ValueTypes
{
    public enum Role
    {
        Admin,
        User
    }
}
