using Chat.Domain.Message;

using Microsoft.AspNetCore.Components;

namespace Chat.WebUI.Pages
{
    public class MessageBase : ComponentBase
    {
        [Parameter]
        public required MessageModel Model { get; set; }

        [Parameter]
        public required bool IsSentByCurrentUser { get; set; }

        public bool visible = true;
        protected string _messageClass = String.Empty;

        protected override Task OnInitializedAsync()
        {
            _messageClass = IsSentByCurrentUser ? "currentUser" : "otherUser";

            return base.OnInitializedAsync();
        }
    }
}
