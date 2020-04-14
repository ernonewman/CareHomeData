using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CareHomeData.Ui.Console.HttpClients;
using CareHomeData.Ui.Console.Interfaces.Services;
using CareHomeData.Ui.Console.Models;

namespace CareHomeData.Ui.Console.Services
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
