﻿global using DbUser = Chat.DataAccess.Entities.User;
global using DomainUser = Chat.ApplicationServices.API.Domain.Models.User;

namespace Chat.ApplicationServices.API.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
