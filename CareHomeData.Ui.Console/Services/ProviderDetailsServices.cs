using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQCViewer.Shared.HttpClients;
using CQCViewer.Shared.Interfaces.Services;
using CQCViewer.Shared.Models;

namespace CQCViewer.Shared.Services
{
    public class ProviderDetailsServices : IProviderDetailsServices
    {
        private readonly ProviderDetailHttpClient _client;
        public ProviderDetailsServices(ProviderDetailHttpClient client)
        {
            _client = client;
        }

        public async Task<ProviderDetail> GetProviderDetails(string providerId)
        {
            return await _client.GetContentFromClient(providerId).ConfigureAwait(false);
        }
    }
}
