using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CareHomeData.Ui.Console.Models;

namespace CareHomeData.Ui.Console.Interfaces.Services
{
    public interface IProvidersSummaryServices
    {
        Task<ProvidersSummary> GetProviderSummary(string providerSummaryUrl);
    }
}
