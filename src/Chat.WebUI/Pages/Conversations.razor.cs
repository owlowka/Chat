using System.Security.Claims;

using Chat.Domain.Conversation;

using Chat.WebUI.Services.Contracts;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Chat.WebUI.Pages
{
    public class ConversationsBase : ComponentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        private ClaimsPrincipal? AuthenticatedUser { get; set; }

        [Parameter]
        public string? UserName { get; set; } /*= "Roksana Duda";*/

        protected FluentSearch? _searchTest;

        protected string? _searchValue = string.Empty;

        public ConversationModel Conversation { get; set; }

        public List<ConversationModel> Conversations { get; set; }

        List<string> _searchData;

        [Inject]
        public IChatService ConversationsListService { get; set; }


        protected List<string> _searchResults = DefaultResults();

        protected static string _defaultResultsText = "no results";
        private static List<string> DefaultResults()
        {
            return new() { _defaultResultsText };
        }

        public void HandleSearchInput()
        {
            if (string.IsNullOrWhiteSpace(_searchValue))
            {
                _searchResults = DefaultResults();
                _searchValue = string.Empty;
            }
            else
            {
                string searchTerm = _searchValue.ToLower();

                if (searchTerm.Length > 0)
                {
                    List<string> temp = _searchData
                        .Where(str => str.ToLower().Contains(searchTerm))
                        .Select(str => str).ToList();
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            //username from autentication as parameter
            AuthenticatedUser = (await AuthenticationState).User;
            UserName ??= AuthenticatedUser.Identity?.Name;
            Conversations = (await ConversationsListService.GetConversationsForUserName(UserName)).ToList();
            _searchData = Conversations
                .Select(conv => conv.Name)
                .ToList();
        }
    }
}
