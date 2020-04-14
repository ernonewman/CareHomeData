using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQCViewer.Shared.Models;

namespace CQCViewer.Shared.Interfaces.Services
{
    public interface IProviderDetailsServices
    {
        Task<ProviderDetail> GetProviderDetails(string providerId);
    }
}
