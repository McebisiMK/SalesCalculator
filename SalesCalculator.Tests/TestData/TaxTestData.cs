using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesCalculator.Common.Models.Configurations;
using SalesCalculator.Core.Interfaces;
using SalesCalculator.Core.Services;

namespace SalesCalculator.Tests.TestData
{
    public class TaxTestData
    {
        public static IConfiguration CreateInMemoryConfigurations()
        {
            var testConfigurations = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("TaxOptions:TaxRate", "10"),
                new KeyValuePair<string, string?>("TaxOptions:ImportRate", "5")
            }.AsEnumerable();

            var configuration = new ConfigurationBuilder()
                                    .AddInMemoryCollection(testConfigurations)
                                    .Build();

            return configuration;
        }

        public static IServiceProvider CreateServiceProvider()
        {
            var configuration = CreateInMemoryConfigurations();
            var serviceProvider = new ServiceCollection()
                                       .Configure<TaxOptions>(configuration.GetSection("TaxOptions"))
                                       .AddScoped<IReceiptGenerator, ReceiptGenerator>()
                                       .AddScoped<ITaxCalculatorService, TaxCalculatorService>()
                                       .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
