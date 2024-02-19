using MediatR;

namespace Chat.Domain.User.GetById
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
