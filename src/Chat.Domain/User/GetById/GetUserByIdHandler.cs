
using AutoMapper;

using Chat.DataAccess.Entities;
using Chat.ApplicationServices.Components.OpenWeather;
using Chat.ApplicationServices.Components.OpenWeather.Models;

using MediatR;
using Chat.ApplicationServices.ErrorHandling;
using Chat.Domain.CQRS;

namespace Chat.Domain.User.GetById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IOpenWeatherClient _openWeatherConnector;

        public GetUserByIdHandler(
            IMapper mapper,
            IQueryExecutor queryExecutor,
            IOpenWeatherClient openWeatherConnector)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _openWeatherConnector = openWeatherConnector;
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery()
            {
                Id = request.Id
            };

            UserEntity user = await _queryExecutor.Execute(query);
            if (user == null)
            {
                return new GetUserByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            UserModel mappedUser = _mapper.Map<UserModel>(user);

            OpenWeatherResponse? weatherResponse = await _openWeatherConnector.Get("Wroclaw");
            DomainWeather weather = _mapper.Map<DomainWeather>(weatherResponse);

            var response = new GetUserByIdResponse()
            {
                Data = mappedUser,
                Weather = weather
            };
            return response;
        }
    }
}
