using AutoMapper;

using Chat.ApplicationServices.API.Domain;
using Chat.DataAccess.CQRS;
using Chat.DataAccess.CQRS.Commands;
using Chat.DataAccess.Entities;
using Chat.ApplicationServices.API.Domain.Models;

using MediatR;

namespace Chat.ApplicationServices.API.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public AddUserHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            DbUser? user = _mapper.Map<DbUser>(request);
            AddUserCommand? command = new AddUserCommand { Parameter = user };
            DbUser? userFromDb = await _commandExecutor.Execute(command);
            return new AddUserResponse()
            {
                Data = _mapper.Map<DomainUser>(userFromDb)
            };

        }
    }
}
