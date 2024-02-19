using AutoMapper;

using Chat.DataAccess.CQRS;
using Chat.DataAccess.CQRS.Commands;
using Chat.DataAccess.Entities;

using MediatR;

namespace Chat.ApplicationServices.Domain.Message.Add
{
    public class AddMessageHandler : IRequestHandler<AddMessageRequest, AddMessageResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public AddMessageHandler(
            ICommandExecutor commandExecutor,
            IMapper mapper
            )
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<AddMessageResponse> Handle(AddMessageRequest request, CancellationToken cancellationToken)
        {
            var message = _mapper.Map<MessageEntity>(request);
            var command = new AddMessageCommand
            {
                Parameter = message
            };

            var messageFromDb = await _commandExecutor.Execute(command);
            return new AddMessageResponse()
            {
                Data = _mapper.Map<MessageModel>(messageFromDb)
            };
        }
    }

}
