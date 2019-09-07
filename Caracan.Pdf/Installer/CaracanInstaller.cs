using Caracan.Pdf.Configuration;
using Caracan.Pdf.Converters;
using Caracan.Pdf.Services.HtmlBuilder;
using Caracan.Pdf.Services.HtmlRenderer;
using Caracan.Pdf.Services.PdfGenerator;
using Caracan.Templates.Extensions;
using Caracan.Templates.Loader;
using Caracan.Templates.Manager;
using Fluid;
using Fluid.Values;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace Caracan.Pdf.Installer
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

            services.AddSingleton<ICaracanPdfGenerator, CaracanPdfGenerator>();

            services.AddSingleton<IFluidBinder, FluidBinder>();
            services.AddSingleton<ITemplateLoader, TemplateLoader>();
            
            //fluid types registration
            TemplateContext.GlobalMemberAccessStrategy.Register<JObject, object>((source, name) => source[name]);
            TemplateContext.GlobalMemberAccessStrategy.Register<JObject, object>((source, name) => source[name]);
            FluidValue.SetTypeMapping(typeof(JObject), o => new ObjectValue(o));
            FluidValue.SetTypeMapping(typeof(JValue), o => FluidValue.Create(((JValue)o).Value));
            
            
            TemplateContext.GlobalFilters.AddFilter("HtmlEncode", CustomFilters.HtmlEncode);
            
            services.AddSingleton<IHtmlRenderer, HtmlRenderer>();
            services.AddSingleton<IReportBuilder, ReportBuilder>();

            return services;
        }
        
        
    }
}
