using Microsoft.JSInterop;

namespace AmbrosiaAlert.Client.Extra
{
    public interface ILocalStorageService
    {
        Task<string> GetItem(string key);
        Task SetItem(string key, string value);
        Task RemoveItem(string key);
    }

    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime js;

        public LocalStorageService(IJSRuntime js)
        {
            this.js = js;
        }

        public async Task<string> GetItem(string key)
        {
            var value = await js.InvokeAsync<string>("localStorage.getItem", key);
            return value;
        }

        public async Task SetItem(string key, string value)
        {
            await js.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        public async Task RemoveItem(string key)
        {
            await js.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
