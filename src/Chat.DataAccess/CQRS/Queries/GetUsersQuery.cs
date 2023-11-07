﻿
using Chat.DataAccess.Entities;

using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public Guid Id { get; set; }

        public override Task<List<User>> Execute(ChatStorageContext context)
        {
            return context.Users.ToListAsync();
        }
    }
}
