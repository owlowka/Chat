using Chat.Domain.Message;
using Chat.Domain.Message.GetAll;
using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components;

namespace Chat.WebUI.Pages
{
    public class MessageListBase : ComponentBase
    {
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
                GetMessagesResponse response = await MessageService.GetMessages();

                List = response.Data;
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
            await RefreshMessagesAsync();
        }
    }
}
