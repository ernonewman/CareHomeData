using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CQCViewer.Shared.Models;

namespace CQCViewer.Shared.HttpClients
{
    public class ProviderSummaryHttpClient
    {
        private HttpClient _client;

        public ProviderSummaryHttpClient(HttpClient client)
        {
            _client = client;
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
                throw;
            }
        }
    }
}
