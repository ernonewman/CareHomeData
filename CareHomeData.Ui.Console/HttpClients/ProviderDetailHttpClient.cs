using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CQCViewer.Shared.Models;

namespace CQCViewer.Shared.HttpClients
{
    public class ProviderDetailHttpClient
    {
        private HttpClient _client;

        public ProviderDetailHttpClient(HttpClient client)
        {
            _client = client;
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
                throw;
            }
        }
    }
}
