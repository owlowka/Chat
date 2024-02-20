using MediatR;

using AutoMapper;
using Chat.Domain.CQRS;
using Chat.DataAccess.Entities;

namespace Chat.Domain.Conversation.Add
{
    public class AddConversationHandler : IRequestHandler<AddConversationRequest, AddConversationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;

        public AddConversationHandler(
            IMapper mapper,
            ICommandExecutor commandExecutor
            )
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
        }
        public async Task<AddConversationResponse> Handle(AddConversationRequest request, CancellationToken cancellationToken)
        {
            var conversation = _mapper.Map<ConversationEntity>(request);

            var command = new AddConversationCommand()
            {
                Parameter = conversation
            };

            var conversationFromDb = await _commandExecutor.Execute(command);

            return new AddConversationResponse()
            {
                Data = _mapper.Map<ConversationModel>(conversationFromDb)
            };
        }
    }
}
