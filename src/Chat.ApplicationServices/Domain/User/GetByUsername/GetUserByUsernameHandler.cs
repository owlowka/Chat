using AutoMapper;

using Chat.DataAccess.Entities;
using Chat.ApplicationServices.Components.OpenWeather;
using Chat.ApplicationServices.Components.OpenWeather.Models;
using Chat.DataAccess.CQRS;
using Chat.DataAccess.CQRS.Queries;

using MediatR;
using Chat.ApplicationServices.ErrorHandling;
using Chat.ApplicationServices.Domain.User;

namespace Chat.ApplicationServices.Domain.User.GetByUsername
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameRequest, GetUserByUsernameResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IOpenWeatherClient _openWeatherConnector;

        public GetUserByUsernameHandler(
            IMapper mapper,
            IQueryExecutor queryExecutor,
            IOpenWeatherClient openWeatherConnector)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _openWeatherConnector = openWeatherConnector;
        }
        public async Task<GetUserByUsernameResponse> Handle(GetUserByUsernameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByUsernameQuery()
            {
                Username = request.Username
            };

            UserEntity user = await _queryExecutor.Execute(query);
            if (user == null)
            {
                return new GetUserByUsernameResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            UserModel mappedUser = _mapper.Map<UserModel>(user);

            OpenWeatherResponse? weatherResponse = await _openWeatherConnector.Get("Wroclaw");
            DomainWeather weather = _mapper.Map<DomainWeather>(weatherResponse);

            var response = new GetUserByUsernameResponse()
            {
                Data = mappedUser,
                Weather = weather
            };
            return response;
        }
    }
}
