using AutoMapper;

using Chat.ApplicationServices.API.Domain;
using Chat.ApplicationServices.API.ErrorHandling;
using Chat.ApplicationServices.Components.OpenWeather;
using Chat.ApplicationServices.Components.OpenWeather.Models;
using Chat.DataAccess.CQRS;
using Chat.DataAccess.CQRS.Queries;

using MediatR;

namespace Chat.ApplicationServices.API.Handlers
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

            DbUser user = await _queryExecutor.Execute(query);
            if (user == null)
            {
                return new GetUserByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            DomainUser mappedUser = _mapper.Map<DomainUser>(user);

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
