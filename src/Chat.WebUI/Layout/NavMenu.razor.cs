using Microsoft.AspNetCore.Components;

namespace Chat.WebUI.Layout
{
    public class NavMenuBase : ComponentBase
    {
        protected bool _collapseNavMenu = true;

        protected string? NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }
    }
}
