﻿using Chat.ApplicationServices.API.Domain.Models;

namespace Chat.ApplicationServices.API.Domain
{
    public class GetUserByIdResponse : ResponseBase<User>
    {
        public DomainWeather Weather { get; internal set; }
    }
}
