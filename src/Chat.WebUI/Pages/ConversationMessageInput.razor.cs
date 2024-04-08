using System.Security.Claims;

using Chat.Domain.Message;
using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Chat.WebUI.Pages
{
    public class ConversationMessageInputBase : ComponentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        [Parameter]
        public required MessageModel Model { get; set; }

        [Parameter]
        public string? UserName { get; set; }

        [Inject]
        private IChatService MessageService { get; set; }

        private ClaimsPrincipal? AuthenticatedUser { get; set; }

        protected bool Sending { get; set; }

        protected string? Value { get; set; }

        public async Task StartSendingAsync()
        {
            Sending = true;

            try
            {
                if (Value is not null)
                {
                    await MessageService.SendMessage(Value, UserName);
                }
                Value = null;
            }
            finally
            {
                Sending = false;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            AuthenticatedUser = (await AuthenticationState).User;
            UserName ??= AuthenticatedUser.Identity?.Name;
        }
    }
}
