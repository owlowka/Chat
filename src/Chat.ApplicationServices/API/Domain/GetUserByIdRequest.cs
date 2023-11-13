using MediatR;

namespace Chat.ApplicationServices.API.Domain
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
