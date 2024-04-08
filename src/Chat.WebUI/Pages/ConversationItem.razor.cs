using Chat.Domain.Conversation;

using Microsoft.AspNetCore.Components;

namespace Chat.WebUI.Pages
{
    public class ConversationItemBase : ComponentBase
    {
        [Parameter]
        public required ConversationModel Model { get; set; }


    }
}
