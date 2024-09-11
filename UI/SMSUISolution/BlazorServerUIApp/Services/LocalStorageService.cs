using BlazorServerUIApp.Services.IServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using System.Text.Json;

namespace BlazorServerUIApp.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private IJSRuntime _jSRuntime;
        public LocalStorageService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async Task<T> GetItem<T>(string key)
        {
            try
            {
                var json = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
                if(json == null)
                    return default;

                return JsonSerializer.Deserialize<T>(json);
            }
            catch(Exception ex) 
            {
                return default;
            }
        }

        public async Task SetItem<T>(string key, T value)
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }

        public async Task RemoveItem(string key)
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task Focus(string elementId)
        {
            await _jSRuntime.InvokeVoidAsync("FocustxtBarcode", elementId);
        }
    }
}
