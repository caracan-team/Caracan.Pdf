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
    class PdfGenerator : IPdfGenerator
    {
        private readonly IHtmlRenderer _renderer;
        private readonly IHtmlBuilder _htmlBuilder;
        private readonly IPdfWriter _pdfWriter;
        private readonly ITemplateManager _templateManager;

        public PdfGenerator(IHtmlRenderer renderer, IHtmlBuilder htmlBuilder, IPdfWriter pdfWriter, ITemplateManager templateManager)
        {
            _renderer = renderer;
            _htmlBuilder = htmlBuilder;
            _pdfWriter = pdfWriter;
            _templateManager = templateManager;
        }

        public async Task<Stream> CreatePdfAsync(CaracanPdfOptions options)
        {
            var templateFileName = "template.liquid";
            var templateLiquidObject = new TemplateLiquidObject
            {
                title = "Caracan Template 1"
            }; // todo: bind liquid template with strongly typed object

            var renderedTemplate = await _templateManager.GetTemplateAndBind(templateFileName, templateLiquidObject);

            var interpolatedHtml = _htmlBuilder.WithTemplate(renderedTemplate)
                .AddCharts(null)
                .GetHtml();
            
            var pdfStream = await _renderer.RenderPdfAsync(interpolatedHtml, options);

            _pdfWriter.RenderOrOmit(pdfStream, options.RenderPdfCurrentDirectory);
            
            return pdfStream;
        }
    }
}