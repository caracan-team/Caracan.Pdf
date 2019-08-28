using System.IO;
using System.Threading.Tasks;
using Caracan.Liquid;
using Caracan.Pdf.Configuration;
using Caracan.Pdf.Services.HtmlBuilder;

namespace Caracan.Pdf.Services.IPdfGenerator
{
    class PdfGenerator : IPdfGenerator
    {
        private readonly ITemplateManager _templateManager;
        private readonly IHtmlRenderer _renderer;
        private readonly IHtmlBuilder _htmlBuilder;

        public PdfGenerator(IHtmlRenderer renderer, ITemplateManager templateManager, IHtmlBuilder htmlBuilder)
        {
            _renderer = renderer;
            _templateManager = templateManager;
            _htmlBuilder = htmlBuilder;
        }


        public async Task<Stream> CreatePdfAsync(string html, PdfOptions options)
        {
            var template = await _templateManager.GetTemplateAsync();

            var interpolatedHtml = _htmlBuilder.WithHtml(template)
                .AddCharts(null)
                .GetHtml();
            
            var pdf = await _renderer.RenderPdfAsync(interpolatedHtml, options);
            
            return pdf;
        }
    }
}