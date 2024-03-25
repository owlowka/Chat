using System.Security.Claims;

using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using Chat.Domain.Message;

namespace Chat.WebUI.Pages
{
    public class MessageListBase : ComponentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public ClaimsPrincipal AuthenticatedUser { get; set; }

        [Parameter]
        public required List<MessageModel>? List { get; set; }

        protected bool _refreshing = false;

        [Inject]
        private IChatService MessageService { get; set; }

        public async Task RefreshMessagesAsync()
        {
            _refreshing = true;

            try
            {
                IEnumerable<MessageModel> messages = await MessageService.GetMessages();

                List = messages.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _refreshing = false;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            AuthenticatedUser = (await AuthenticationState).User;

            await RefreshMessagesAsync();
        }
    }
}
