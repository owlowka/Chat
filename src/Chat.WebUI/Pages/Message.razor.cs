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

        protected bool IsInfoVisible { get; set; } = false;

        protected string? MessageClass { get; set; }

        protected override Task OnInitializedAsync()
        {
            MessageClass = IsSentByCurrentUser ? "currentUser" : "otherUser";

            return base.OnInitializedAsync();
        }

        protected void ToggleInfoVisibility()
        {
            IsInfoVisible = !IsInfoVisible;
            Console.WriteLine($"ToggleInfoVisibility {IsInfoVisible}");
            StateHasChanged();
        }
    }
}
