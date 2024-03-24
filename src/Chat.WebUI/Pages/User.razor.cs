using System.Security.Claims;
using System.Text.Json;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Chat.WebUI.Pages
{
    public class UserBase : ComponentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        [Inject]
        private IAccessTokenProvider AuthorizationService { get; set; }

        public ClaimsPrincipal AuthenticatedUser { get; set; }
        public AccessToken AccessToken { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            AuthenticationState state = await AuthenticationState;
            AccessTokenResult accessTokenResult = await AuthorizationService.RequestAccessToken();

            if (!accessTokenResult.TryGetToken(out AccessToken? token))
            {
                throw new InvalidOperationException(
                    "Failed to provision the access token.");
            }

            AccessToken = token;

            AuthenticatedUser = state.User;
        }

        protected IDictionary<string, string> GetAccessTokenClaims()
        {
            if (AuthenticatedUser == null)
            {
                return new Dictionary<string, string>();
            }

            return AuthenticatedUser.Claims.ToDictionary(c => c.Type, c => c.Value);
        }
    }
}