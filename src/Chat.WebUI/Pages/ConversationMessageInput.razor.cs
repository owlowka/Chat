using Chat.Domain.Message;
using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Chat.WebUI.Pages
{
    public class ConversationMessageInputBase : ComponentBase
    {
        [Parameter]
        public required MessageModel Model { get; set; }

        protected bool _sending = false;
        protected string? _value;
        protected string _username;

        [Inject]
        private IChatService MessageService { get; set; }

        public async Task StartSendingAsync()
        {
            _sending = true;

            try
            {
                if (_value is not null)
                {
                    await MessageService.SendMessage(_value, _username);
                }
                _value = null;
            }
            finally
            {
                _sending = false;
            }
        }
    }
}
