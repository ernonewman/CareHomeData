using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CareHomeData.Ui.Console.Models;
using Microsoft.Extensions.Logging;

namespace CareHomeData.Ui.Console.HttpClients
{
    public class ProviderDetailHttpClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<ProviderDetailHttpClient> _logger;

        public ProviderDetailHttpClient(HttpClient client, ILogger<ProviderDetailHttpClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<ProviderDetail> GetContentFromClient(string providerId)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    AllowTrailingCommas = true
                };


                var json = await _client.GetStreamAsync($"https://api.cqc.org.uk/public/v1/providers/{providerId}").ConfigureAwait(false);

                return await JsonSerializer.DeserializeAsync<ProviderDetail>(json, options);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"An error occurred while trying to retrieve Provider details for id: {providerId}");
                throw;
            }
        }
    }
}
