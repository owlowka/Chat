using Chat.Domain.Message.GetAll;
using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components;

namespace Chat.WebUI.Pages.Message
{
    public class MessagesBase : ComponentBase
    {
        [Inject]
        public IMessageService MessageService { get; set; }

        public GetMessagesResponse Messages { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Messages = await MessageService.GetMessages();
        }

    }
}
