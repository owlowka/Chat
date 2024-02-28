using Chat.Domain.Message;

using Microsoft.AspNetCore.Components;

namespace Chat.WebUI.Pages.Conversation
{
    public class ConversationMessageBase : ComponentBase
    {
        [Parameter]
        public required MessageModel Model { get; set; }
    }
}
