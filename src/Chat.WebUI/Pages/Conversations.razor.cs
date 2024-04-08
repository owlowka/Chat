using Chat.Domain.Conversation;
using Chat.Domain.User;
using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Chat.WebUI.Pages
{
    public class ConversationsBase : ComponentBase
    {
        protected FluentSearch? _searchTest;

        protected string? _searchValue = string.Empty;

        public ConversationModel Conversation { get; set; }

        public IEnumerable<ConversationModel> Conversations { get; set; }

        [Inject]
        public IChatService HttpChatService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Conversations = await HttpChatService.GetConversations();
        }
    }
}
