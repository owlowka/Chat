using Chat.Domain.Conversation.Add;
using Chat.Domain.Conversation.GetAll;
using Chat.Domain.Conversation.GetByName;
using Chat.Domain.Message;
using Chat.Domain.User;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversationsController : ApiControllerBase
    {
        public ConversationsController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<ActionResult<GetConversationsResponse>> GetAllConversations([FromQuery] GetConversationsRequest request)
        {
            return HandleRequest<GetConversationsRequest, GetConversationsResponse>(request);
        }

        //[HttpGet]
        //[Route("")]
        //public async Task<ActionResult<GetConversationByNameResponse>> GetConversationsForUserName([FromRoute] string userName)
        //{
        //    return Ok(new GetConversationsResponse
        //    {
        //        Data =
        //        [
        //            new()
        //            {
        //                Messages = [
        //                    new MessageModel()
        //                    {
        //                        Content = "",
        //                        UserName = ""
        //                    }],
        //                Users = [
        //                    new UserModel
        //                    {
        //                        Username = ""
        //                    }]
        //            },
        //            new()
        //            {
        //                Messages = [
        //                    new MessageModel()
        //                    {
        //                        Content = "",
        //                        UserName = ""
        //                    },
        //                    new MessageModel()
        //                    {
        //                        Content = "",
        //                        UserName = ""
        //                    }],
        //                Users = [
        //                    new UserModel
        //                    {
        //                        Username = ""
        //                    }]
        //            }
        //        ]
        //    });
        //}


        [HttpGet]
        [Route("{conversationName}")]
        public Task<ActionResult<GetConversationByNameResponse>> GetConversationByName([FromRoute] string conversationName)
        {
            var request = new GetConversationByNameRequest()
            {
                Name = conversationName
            };
            return HandleRequest<GetConversationByNameRequest, GetConversationByNameResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<ActionResult<AddConversationResponse>> AddConversation([FromBody] AddConversationRequest request)
        {
            return HandleRequest<AddConversationRequest, AddConversationResponse>(request);
        }
    }
}
