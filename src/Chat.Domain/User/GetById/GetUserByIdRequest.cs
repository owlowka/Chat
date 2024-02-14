using MediatR;

namespace Chat.ApplicationServices.Domain.User.GetById
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
