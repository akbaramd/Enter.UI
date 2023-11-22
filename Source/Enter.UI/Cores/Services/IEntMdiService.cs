using Microsoft.AspNetCore.Components;

namespace Enter.UI.Services
{
    public interface IEntMdiService
    {

        public Task AddNewTabAsync<TComponent>(string id , string title,object icon, Dictionary<string, object>? parameters = null) where TComponent : ComponentBase;
        public Task AddNewTabAsync(string id , Type type, string title, object icon, Dictionary<string, object>? parameters = null);
        public Task CloseTabAsync(string id);
        public Task ActivateTabAsync(string id);
    }
}
