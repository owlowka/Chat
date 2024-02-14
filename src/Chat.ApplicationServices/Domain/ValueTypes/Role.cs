global using DbRole = Chat.DataAccess.Entities.Role;
global using DomainRole = Chat.ApplicationServices.Domain.ValueTypes.Role;

namespace Chat.ApplicationServices.Domain.ValueTypes
{
    public enum Role
    {
        Admin,
        User
    }
}
