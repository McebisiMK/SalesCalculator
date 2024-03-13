using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesCalculator.Common.Models.Configurations;
using SalesCalculator.Core.Interfaces;
using SalesCalculator.Core.Services;

namespace SalesCalculator.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<TaxOptions>(configuration.GetSection("TaxOptions"));
            services.AddScoped<IReceiptGenerator, ReceiptGenerator>();
            services.AddScoped<ITaxCalculatorService, TaxCalculatorService>();

            return services;
        }
    }
}
