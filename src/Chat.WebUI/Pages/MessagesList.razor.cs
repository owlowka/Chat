using Chat.Domain.Message;

using Microsoft.AspNetCore.Components;

namespace Chat.WebUI.Pages
{
    public class MessageListBase : ComponentBase
    {
        [Parameter]
        public required List<MessageModel> List { get; set; }
    }
}
