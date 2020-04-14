using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareHomeData.Ui.Console.HttpClients;
using CareHomeData.Ui.Console.Interfaces.Services;
using CareHomeData.Ui.Console.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CareHomeData.Ui.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger =
                new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();

            try
            {
                Log.Information("Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<IProvidersSummaryServices, ProviderSummaryServices>();
                    services.AddTransient<IProviderDetailsServices, ProviderDetailsServices>();
                    services.AddHttpClient<ProviderSummaryHttpClient>();
                    services.AddHttpClient<ProviderDetailHttpClient>();
                })
                .UseSerilog();
    }
}
