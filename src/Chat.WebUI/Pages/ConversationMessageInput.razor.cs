using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components;

namespace Chat.WebUI.Pages
{
    public class ConversationMessageInputBase : ComponentBase
    {
        protected bool _sending = false;
        protected string? _value;

        [Inject]
        private IChatService MessageService { get; set; }

        public async Task StartSendingAsync()
        {
            _sending = true;

            try
            {
                if (_value is not null)
                {
                    await MessageService.SendMessage(_value);
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
