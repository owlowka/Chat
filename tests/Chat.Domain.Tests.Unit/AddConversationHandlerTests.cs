using AutoMapper;

using Chat.Domain.Conversation.Add;
using Chat.Domain.CQRS;

namespace Chat.ApplicationServices.Tests
{
    [TestFixture]
    public class AddConversationHandlerTests
    {
        private static AddConversationHandler CreateSut()
        {
            IMapper mapper = Mock.Of<IMapper>();
            ICommandExecutor commandExecutor = Mock.Of<ICommandExecutor>();

            return new(mapper, commandExecutor);
        }

        [Test]
        public async Task Handle_ReturnsNullOrEmptyResponse_When_RequestIsNullOrEmpty()
        {
            //Arrange
            AddConversationHandler sut = CreateSut();

            AddConversationRequest request = null!;

            //Act
            await sut.Awaiting(h => h.Handle(request))
            //Assert
                .Should()
                .ThrowExactlyAsync<ArgumentNullException>();
        }

        [Test]
        public async Task Handle_ShouldNotThrow_When_RequestIsNotNull()
        {
            //Arrange
            AddConversationHandler sut = CreateSut();

            AddConversationRequest request = new()
            {
                Messages = [],
                Users = []
            };

            //Act
            await sut.Awaiting(h => h.Handle(request))
            //Assert
                .Should()
                .NotThrowAsync();
        }

        [Test]
        public async Task Handle_ShouldReturnNotNullResponse_When_RequestIsNotNull()
        {
            //Arrange
            AddConversationHandler sut = CreateSut();

            AddConversationRequest request = new()
            {
                Messages = [],
                Users = []
            };

            //Act
            AddConversationResponse response = await sut.Handle(request);

            //Assert
            response
                .Should()
                .NotBeNull();
        }
    }
}