using System;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using MK.Getoky.Web.Models;
using MK.Getoky.Web.Pages;

namespace MK.Getoky.Web.Services
{
    public class BrowserLocalStorageService : IStorageService
    {
        private readonly IJSRuntime js;
        private readonly ILogger<BrowserLocalStorageService> logger;

        public BrowserLocalStorageService(IJSRuntime js, ILogger<BrowserLocalStorageService> logger)
        {
            this.js = js;
            this.logger = logger;
        }

        public async Task SetAsync<T>(string key, T value)
        {
            logger.LogInformation($"Setting item {key}");
            string serialisedItem = JsonSerializer.Serialize(value);
            await js.InvokeVoidAsync("localStorage.setItem", key, serialisedItem);
            logger.LogInformation($"Finished setting item {key}");
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            logger.LogInformation($"Getting item {key}");
            T? item = default;

            string serialisedData = await js.InvokeAsync<string>("localStorage.getItem", key);
            if (!string.IsNullOrWhiteSpace(serialisedData))
            {
                item = JsonSerializer.Deserialize<T>(serialisedData)!;
            }

            logger.LogInformation($"Finished getting item {key}");
            return item;
        }

        public async Task RemoveAsync(string key)
        {
            logger.LogInformation($"Removing item {key}");
            await js.InvokeVoidAsync("localStorage.removeItem", key);
            logger.LogInformation($"Finished removing item {key}");
        }
    }
}

