using Caracan.Pdf.Configuration;
using Caracan.Pdf.Converters;
using Caracan.Pdf.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Caracan.Pdf.Extensions
{
    public static class PdfGeneratorExtensions
    {
        public static IServiceCollection AddPdfGenerator(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PdfGeneratorOptions>(configuration);
            services.AddTransient<IPdfOptionsConverter, PdfOptionsConverter>();
            services.AddSingleton<IPdfGenerator, PdfGenerator>();

            return services;
        }
    }
}
