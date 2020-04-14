using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CareHomeData.Ui.Console.DataContext;
using CareHomeData.Ui.Console.Interfaces.Services;
using CareHomeData.Ui.Console.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace CareHomeData.Ui.Console
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IProviderDetailsServices _providerDetailsServices;
        private readonly IProvidersSummaryServices _providersSummaryServices;

        private bool exitGracefully = false;

        public Worker(
            ILogger<Worker> logger,
            IProviderDetailsServices providerDetailsServices,
            IProvidersSummaryServices providersSummaryServices)
        {
            _logger = logger;
            _providerDetailsServices = providerDetailsServices;
            _providersSummaryServices = providersSummaryServices;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested && !exitGracefully)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await UpdateProviderSummaryData();

                await UpdateProviderDetails();

                await Task.Delay(1000, stoppingToken);

                exitGracefully = true;
            }
        }

        private async Task UpdateProviderDetails()
        {
            try
            {
                _logger.LogInformation("Updating providers details.");

                using (var db = new SQLiteContext())
                {
                    var allDetails = db.ProviderDetails.ToList();

                    if (allDetails.Any())
                    {
                        var totalRecordsToCheck = allDetails.Count();

                        _logger.LogInformation($"{totalRecordsToCheck} records to check.");

                        for (int i = 0; i < totalRecordsToCheck; i++)
                        {
                            var detail = allDetails.ElementAt(i);

                            _logger.LogInformation($"Checking record {i} of {totalRecordsToCheck} - Provider: {detail.name} - Id: {detail.providerId}");

                            var apiDetail = await _providerDetailsServices.GetProviderDetails(detail.providerId);

                            await UpdateIndividualDetails(detail, apiDetail, db, totalRecordsToCheck % 50 == 0);
                        }

                        _logger.LogInformation($"Saving batched changes to database.");
                        await db.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error occurred while updating provider details");
            }
        }

        private async Task UpdateIndividualDetails(ProviderDetail detail, ProviderDetail apiDetail, SQLiteContext db, bool saveRecordsToDatabase)
        {
            var recordUpdated = false;

            if (detail.locationIds != apiDetail.locationIds)
            {
                detail.locationIds = apiDetail.locationIds;
                recordUpdated = true;
            }

            if (detail.organisationType != apiDetail.organisationType)
            {
                detail.organisationType = apiDetail.organisationType;
                recordUpdated = true;
            }

            if (detail.name != apiDetail.name)
            {
                detail.name = apiDetail.name;
                recordUpdated = true;
            }

            if (detail.alsoKnownAs != apiDetail.alsoKnownAs)
            {
                detail.alsoKnownAs = apiDetail.alsoKnownAs;
                recordUpdated = true;
            }

            if (detail.registrationStatus != apiDetail.registrationStatus)
            {
                detail.registrationStatus = apiDetail.registrationStatus;
                recordUpdated = true;
            }

            if (detail.registrationDate != apiDetail.registrationDate)
            {
                detail.registrationDate = apiDetail.registrationDate;
                recordUpdated = true;
            }

            if (detail.website != apiDetail.website)
            {
                detail.website = apiDetail.website;
                recordUpdated = true;
            }

            if (detail.postalAddressLine1 != apiDetail.postalAddressLine1)
            {
                detail.postalAddressLine1 = apiDetail.postalAddressLine1;
                recordUpdated = true;
            }

            if (detail.postalAddressLine2 != apiDetail.postalAddressLine2)
            {
                detail.postalAddressLine2 = apiDetail.postalAddressLine2;
                recordUpdated = true;
            }

            if (detail.postalAddressTownCity != apiDetail.postalAddressTownCity)
            {
                detail.postalAddressTownCity = apiDetail.postalAddressTownCity;
                recordUpdated = true;
            }

            if (detail.postalAddressCounty != apiDetail.postalAddressCounty)
            {
                detail.postalAddressCounty = apiDetail.postalAddressCounty;
                recordUpdated = true;
            }

            if (detail.region != apiDetail.region)
            {
                detail.region = apiDetail.region;
                recordUpdated = true;
            }

            if (detail.postalCode != apiDetail.postalCode)
            {
                detail.postalCode = apiDetail.postalCode;
                recordUpdated = true;
            }

            if (detail.mainPhoneNumber != apiDetail.mainPhoneNumber)
            {
                detail.mainPhoneNumber = apiDetail.mainPhoneNumber;
                recordUpdated = true;
            }

            if (recordUpdated)
            {
                _logger.LogInformation($"Differences found. Updating record for Provider: {detail.name} - Id: {detail.providerId}.");
                db.ProviderDetails.Update(detail);
            }
            else
            {
                _logger.LogInformation($"No differences found for record for Provider: {detail.name} - Id: {detail.providerId}.");
            }

            if (saveRecordsToDatabase)
            {
                _logger.LogInformation($"Saving batched changes to database.");
                await db.SaveChangesAsync();
            }
        }

        private async Task UpdateProviderSummaryData()
        {
            try
            {
                _logger.LogInformation("Updating providers summery data.");

                var providersSummary = await _providersSummaryServices.GetProviderSummary(string.Empty);

                await GetDetailsAndAddToDatabase(providersSummary);

                // while (providersSummary.nextPageUri != null)
                // {
                //     providersSummary = await myService.GetProviderSummary(providersSummary.nextPageUri);

                //     GetDetailsAndAddToDatabase(providersSummary, db);
                // }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error occurred while updating provider summary data");
            }
        }

        private async Task GetDetailsAndAddToDatabase(ProvidersSummary providersSummary)
        {
            try
            {
                _logger.LogInformation($"Page: {providersSummary.page} of {providersSummary.totalPages}");

                using (var db = new SQLiteContext())
                {
                    foreach (var item in providersSummary.providers.ToList())
                    {
                        var providerDetails = db.ProviderDetails.FirstOrDefault(x => x.providerId == item.providerId);

                        if (providerDetails == null)
                        {
                            _logger.LogInformation($"No details found for {item.providerName}. Adding to database.");

                            providerDetails = new ProviderDetail
                            {
                                providerId = item.providerId,
                                name = item.providerName
                            };

                            await db.ProviderDetails.AddAsync(providerDetails);
                        }
                        else
                        {
                            _logger.LogInformation($"Existing details found for {item.providerName}. Skipping.");
                        }
                    }

                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating provider summary data for page {providersSummary.page}");
            }
        }
    }
}
