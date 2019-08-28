using Caracan.Liquid;
using Caracan.Pdf.Configuration;
using Caracan.Pdf.Converters;
using Caracan.Pdf.Services;
using Caracan.Pdf.Services.IPdfGenerator;
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
            services.AddSingleton<IHtmlRenderer, HtmlRenderer>();
            services.AddSingleton<ITemplateManager, TemplateManager>();

            return services;
        }
    }
}
