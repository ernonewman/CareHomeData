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
    public class ProviderSummaryHttpClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<ProviderSummaryHttpClient> _logger;

        public ProviderSummaryHttpClient(HttpClient client, ILogger<ProviderSummaryHttpClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<ProvidersSummary> GetContentFromClient(string providerSummaryUrl = "")
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    AllowTrailingCommas = true
                };


                var json = await _client.GetStreamAsync(string.IsNullOrWhiteSpace(providerSummaryUrl) ? "https://api.cqc.org.uk/public/v1/providers?perPage=10000" : $"https://api.cqc.org.uk/public/v1{providerSummaryUrl}").ConfigureAwait(false);

                return await JsonSerializer.DeserializeAsync<ProvidersSummary>(json, options);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "An error occurred while trying to retrieve Provider Summary details");
                throw;
            }
        }
    }
}
