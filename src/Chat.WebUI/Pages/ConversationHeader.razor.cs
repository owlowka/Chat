using Chat.Domain.User;

using Microsoft.AspNetCore.Components;

namespace Chat.WebUI.Pages
{
    public class ConversationHeaderBase : ComponentBase
    {
        [Parameter]
        public required UserModel Model { get; set; }
    }
}
