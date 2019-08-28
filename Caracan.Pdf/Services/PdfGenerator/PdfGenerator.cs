using System;
using System.IO;
using System.Threading.Tasks;
using Caracan.Liquid;
using Caracan.Pdf.Configuration;
using Caracan.Pdf.Extensions;
using Caracan.Pdf.Services.HtmlBuilder;

namespace Caracan.Pdf.Services.IPdfGenerator
{
    class PdfGenerator : IPdfGenerator
    {
        private readonly ITemplateManager _templateManager;
        private readonly IHtmlRenderer _renderer;
        private readonly IHtmlBuilder _htmlBuilder;
        private readonly IPdfWriter _pdfWriter;

        public PdfGenerator(IHtmlRenderer renderer, ITemplateManager templateManager, IHtmlBuilder htmlBuilder, IPdfWriter pdfWriter)
        {
            _renderer = renderer;
            _templateManager = templateManager;
            _htmlBuilder = htmlBuilder;
            _pdfWriter = pdfWriter;
        }


        public async Task<Stream> CreatePdfAsync(PdfOptions options)
        {
            var template = await _templateManager.GetTemplateAsync();

            var interpolatedHtml = _htmlBuilder.WithHtml(template)
                .AddCharts(null)
                .GetHtml();
            
            var pdfStream = await _renderer.RenderPdfAsync(interpolatedHtml, options);

            _pdfWriter.RenderOrOmit(pdfStream, options.RenderPdfCurrentDirectory);
            
            return pdfStream;
        }



    }
}