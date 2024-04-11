using Microsoft.AspNetCore.Components;

using Chat.WebUI.Services.Contracts;

using Chat.Domain.Conversation;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Chat.WebUI.Pages
{
    public class ConversationsListBase : ComponentBase
    {
        [Parameter]
        public required List<ConversationModel>? List { get; set; }

    }
}
