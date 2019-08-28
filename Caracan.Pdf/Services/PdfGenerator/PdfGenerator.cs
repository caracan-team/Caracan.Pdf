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
        private readonly ITemplateLoader _templateLoader;
        private readonly IHtmlRenderer _renderer;
        private readonly IHtmlBuilder _htmlBuilder;
        private readonly IPdfWriter _pdfWriter;

        public PdfGenerator(IHtmlRenderer renderer, ITemplateLoader templateLoader, IHtmlBuilder htmlBuilder, IPdfWriter pdfWriter)
        {
            _renderer = renderer;
            _templateLoader = templateLoader;
            _htmlBuilder = htmlBuilder;
            _pdfWriter = pdfWriter;
        }

        public async Task<Stream> CreatePdfAsync(CaracanPdfOptions options)
        {
            var templateFileName = "template.liquid";
            var template = await _templateLoader.GetTemplateAsync(templateFileName);
            
            var bindingTemplateObjcect = new TemplateLiquidObject();

            var interpolatedHtml = _htmlBuilder.WithHtml(template, bindingTemplateObjcect)
                .AddCharts(null)
                .GetHtml();
            
            var pdfStream = await _renderer.RenderPdfAsync(interpolatedHtml, options);

            _pdfWriter.RenderOrOmit(pdfStream, options.RenderPdfCurrentDirectory);
            
            return pdfStream;
        }
    }
}