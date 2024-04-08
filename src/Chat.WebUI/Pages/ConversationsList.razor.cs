using Microsoft.AspNetCore.Components;

using Chat.WebUI.Services.Contracts;

using Chat.Domain.Conversation;

namespace Chat.WebUI.Pages
{
    public class ConversationsListBase : ComponentBase
    {
        [Parameter]
        public required List<ConversationModel>? List { get; set; }

        protected bool _refreshing = false;

        [Inject]
        private IChatService ConversationService { get; set; }

        public async Task RefreshConversationsAsync()
        {
            _refreshing = true;

            try
            {
                IEnumerable<ConversationModel> conversations = await ConversationService.GetConversations();

                List = conversations.ToList();
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
            await RefreshConversationsAsync();
        }
    }
}
