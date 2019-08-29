using System;
using System.IO;
using System.Threading.Tasks;
using Caracan.Liquid;
using Caracan.Pdf.Configuration;
using Caracan.Pdf.Extensions;
using Caracan.Pdf.Services.HtmlBuilder;
using Caracan.Templates;

namespace Caracan.Pdf.Services.IPdfGenerator
{
    class CaracanPdfGenerator : ICaracanPdfGenerator
    {
        private readonly IHtmlRenderer _renderer;
        private readonly IHtmlBuilder _htmlBuilder;
        private readonly ITemplateManager _templateManager;

        public CaracanPdfGenerator(IHtmlRenderer renderer, IHtmlBuilder htmlBuilder, ITemplateManager templateManager)
        {
            _renderer = renderer;
            _htmlBuilder = htmlBuilder;
            _templateManager = templateManager;
        }

        public async Task<Stream> CreatePdfAsync(CaracanPdfOptions options)
        {
            //todo: template file name passed from higher level, not hardcoded. 
            const string templateFileName = "template.liquid";
            var boundTemplate = await GetBoundTemplateAsync(templateFileName);
            
            //unused yet, but might be a right direction for fluent building HTML, appending charts and stuff.
            //alternatively charts might need un-processed fluid template for some reason so that would need some refactor.
            var html = _htmlBuilder.WithTemplate(boundTemplate)
                .AddCharts(null)
                .GetHtml();
            
            //renders HTML to Stream
            var pdfStream = await _renderer.RenderHtmlToPdfAsync(html, options);
            
            //Renders Stream to Pdf File
            if (options.RenderPdfCurrentDirectory) pdfStream.ToPdf();

            return pdfStream;
        }

        private async Task<string> GetBoundTemplateAsync(string templateFileName)
        {
            var templateLiquidObject = new TemplateLiquidObject
            {
                title = "Caracan Template 1"
            }; // todo: bind liquid template with strongly typed object

            
            var boundTemplate = await _templateManager.GetTemplateAndBind(templateFileName, templateLiquidObject);
            return boundTemplate;
        }
    }
}