﻿using AutoMapper;

using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;

using MediatR;


namespace Chat.Domain.User.GetAll
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();
            List<UserEntity>? users = await _queryExecutor.Execute(query);
            List<UserModel>? mappedUser = _mapper.Map<List<UserModel>>(users);

            var response = new GetUsersResponse()
            {
                Data = mappedUser
            };

            return response;

        }
    }
}
