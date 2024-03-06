using Chat.Domain.Message;
using Chat.Domain.Message.GetAll;
using Chat.Domain.User;
using Chat.Domain.User.GetByUsername;
using Chat.WebUI.Services;
using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components;

namespace Chat.WebUI.Pages
{
    public class ConversationBase : ComponentBase
    {
        private string _userName;
        public UserModel User { get; set; }
        public IEnumerable<MessageModel> Messages { get; set; }

        [Inject]
        public IChatService HttpChatService { get; set; }

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
            User = await HttpChatService.GetUserProfile(UserName);
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            Messages = await HttpChatService.GetMessages();
        }

    }
}
