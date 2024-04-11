using Chat.Domain.Conversation;
using Chat.Domain.User;
using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Chat.WebUI.Pages
{
    public class ConversationsBase : ComponentBase
    {
        [Parameter]
        public string? UserName { get; set; } = "Roksana Duda";

        protected FluentSearch? _searchTest;

        protected string? _searchValue = string.Empty;

        public ConversationModel Conversation { get; set; }

        public List<ConversationModel> Conversations { get; set; }

        [Inject]
        public IChatService HttpChatService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //username from autentication as parameter
            Conversations = (await HttpChatService.GetConversationsForUserName(UserName)).ToList();
        }
    }
}
