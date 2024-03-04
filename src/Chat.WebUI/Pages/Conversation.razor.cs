using Chat.Domain.Message.GetAll;
using Chat.Domain.User.GetByUsername;
using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components;

namespace Chat.WebUI.Pages
{
    public class ConversationBase : ComponentBase
    {
        private string _userName;

        [Inject]
        public IMessageService MessageService { get; set; }

        public string? UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                //RefreshUser();
            }
        }

        public async Task RefreshUser()
        {
            User = await MessageService.GetUserProfile(UserName);
            StateHasChanged();
        }

        public GetUserByUsernameResponse User { get; set; }
        public GetMessagesResponse Messages { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Messages = await MessageService.GetMessages();
        }

    }
}
