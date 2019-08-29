using Caracan.Liquid;
using Caracan.Pdf.Configuration;
using Caracan.Pdf.Converters;
using Caracan.Pdf.Services;
using Caracan.Pdf.Services.HtmlBuilder;
using Caracan.Pdf.Services.IPdfGenerator;
using Caracan.Templates;
using Fluid;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Caracan.Pdf.Extensions
{
    public static class PdfGeneratorExtensions
    {
        private const string PdfGeneratorSection = "caracan";
        
        public static IServiceCollection AddCaracan(this IServiceCollection services, string section = PdfGeneratorSection)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }
            var options = configuration.GetSection(section).Get<ChromeConnectionOptions>();    
            
            services.AddSingleton(options);
            services.AddTransient<IPdfOptionsConverter, PdfOptionsConverter>();

            services.AddSingleton<ICaracanPdfGenerator, PdfGenerator>();

            services.AddSingleton<ITemplateManager, TemplateManager>();
            services.AddSingleton<ITemplateLoader, TemplateLoader>();
            TemplateContext.GlobalMemberAccessStrategy.Register<TemplateLiquidObject>();
            
            services.AddSingleton<IHtmlRenderer, HtmlRenderer>();
            services.AddSingleton<IHtmlBuilder, HtmlBuilder>();
            
            services.AddSingleton<IPdfWriter, PdfWriter>();

            return services;
        }
    }
}
