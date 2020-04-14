using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQCViewer.Shared.Models;

namespace CQCViewer.Shared.Interfaces.Services
{
    public interface IProvidersSummaryServices
    {
        Task<ProvidersSummary> GetProviderSummary(string providerSummaryUrl);
    }
}
