using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CareHomeData.Ui.Console.HttpClients;
using CareHomeData.Ui.Console.Interfaces.Services;
using CareHomeData.Ui.Console.Models;

namespace CareHomeData.Ui.Console.Services
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
