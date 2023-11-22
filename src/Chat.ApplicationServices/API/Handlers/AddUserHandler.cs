using AutoMapper;

using Chat.ApplicationServices.API.Domain;
using Chat.ApplicationServices.Components.OpenWeather;
using Chat.DataAccess.CQRS;
using Chat.DataAccess.CQRS.Commands;

using MediatR;

namespace Chat.ApplicationServices.API.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;
        private readonly IOpenWeatherClient _openWeatherConnector;

        public AddUserHandler(
            ICommandExecutor commandExecutor,
            IMapper mapper,
            IOpenWeatherClient openWeatherConnector)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
            _openWeatherConnector = openWeatherConnector;
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
