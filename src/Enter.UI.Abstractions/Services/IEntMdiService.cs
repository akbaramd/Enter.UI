using Microsoft.AspNetCore.Components;

namespace Enter.UI.Abstractions.Services
{
    public interface IEntMdiService
    {

        public Task AddNewTabAsync<TComponent>(string id , string title,string icon, Dictionary<string, object>? parameters = null) where TComponent : ComponentBase;
        public Task AddNewTabAsync(string id , Type type, string title, string icon, Dictionary<string, object>? parameters = null);
        public Task CloseTabAsync(string id);
        public Task ActivateTabAsync(string id);
    }
}
