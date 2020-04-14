using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQCViewer.Shared.HttpClients;
using CQCViewer.Shared.Interfaces.Services;
using CQCViewer.Shared.Models;

namespace CQCViewer.Shared.Services
{
    public class ProviderSummaryServices : IProvidersSummaryServices
    {
        private readonly ProviderSummaryHttpClient _client;
        public ProviderSummaryServices(ProviderSummaryHttpClient client)
        {
            _client = client;
        }

        public async Task<ProvidersSummary> GetProviderSummary(string providerSummaryUrl)
        {
            return await _client.GetContentFromClient(providerSummaryUrl).ConfigureAwait(false);
        }
    }
}
