using AutoMapper;

using Chat.ApplicationServices.API.Domain;
using Chat.ApplicationServices.API.Domain.Models;
using Chat.ApplicationServices.Components.OpenWeather;
using Chat.ApplicationServices.Components.Password;
using Chat.DataAccess.Entities;
using Chat.DataAccess.CQRS;
using Chat.DataAccess.CQRS.Commands;
using Chat.ApplicationServices.Components.Password;

using MediatR;

namespace Chat.ApplicationServices.API.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;
        private readonly IOpenWeatherClient _openWeatherConnector;
        private readonly PasswordHasher _passwordHasher;

        public AddUserHandler(
            ICommandExecutor commandExecutor,
            IMapper mapper,
            IOpenWeatherClient openWeatherConnector,
            PasswordHasher passwordHasher)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
            _openWeatherConnector = openWeatherConnector;
            _passwordHasher = passwordHasher;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {

            UserEntity? user = _mapper.Map<UserEntity>(request);

            user.Password = _passwordHasher.HashPassword(request.Password);

            AddUserCommand? command = new AddUserCommand { Parameter = user };
            UserEntity? userFromDb = await _commandExecutor.Execute(command);
            return new AddUserResponse()
            {
                Data = _mapper.Map<UserModel>(userFromDb)
            };

        }
    }
}
