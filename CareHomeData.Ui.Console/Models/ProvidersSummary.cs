using System;
using System.Collections.Generic;
using System.Text;

namespace CQCViewer.Shared.Models
{
    public class ProvidersSummary
    {
        public int total { get; set; }

        public string firstPageUri { get; set; }

        public int page { get; set; }

        public object previousPageUri { get; set; }

        public string lastPageUri { get; set; }

        public string nextPageUri { get; set; }

        public int perPage { get; set; }

        public int totalPages { get; set; }

        public ProviderSummary[] providers { get; set; }

        public string uri { get; set; }
    }

    public class ProviderSummary
    {
        public string providerId { get; set; }

        public string providerName { get; set; }
    }

}
