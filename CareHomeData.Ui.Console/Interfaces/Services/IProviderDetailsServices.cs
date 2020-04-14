using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CareHomeData.Ui.Console.Models;

namespace CareHomeData.Ui.Console.Interfaces.Services
{
    public interface IProviderDetailsServices
    {
        Task<ProviderDetail> GetProviderDetails(string providerId);
    }
}
