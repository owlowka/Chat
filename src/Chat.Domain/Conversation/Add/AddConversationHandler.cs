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
            ArgumentNullException.ThrowIfNull(mapper);
            ArgumentNullException.ThrowIfNull(commandExecutor);

            _mapper = mapper;
            _commandExecutor = commandExecutor;
        }
        public async Task<AddConversationResponse> Handle(AddConversationRequest request, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);

            ConversationEntity conversation = _mapper.Map<ConversationEntity>(request);

            var command = new AddConversationCommand()
            {
                Parameter = conversation
            };

            ConversationEntity conversationFromDb = await _commandExecutor.Execute(command);

            return MapToResponse(conversationFromDb);
        }

        private AddConversationResponse MapToResponse(ConversationEntity conversationFromDb) =>
            new()
            {
                Data = _mapper.Map<ConversationModel>(conversationFromDb)
            };
    }
}
