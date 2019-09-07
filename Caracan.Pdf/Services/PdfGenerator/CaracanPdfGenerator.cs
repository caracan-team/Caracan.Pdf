using System.IO;
using System.Threading.Tasks;
using Caracan.Pdf.Configuration;
using Caracan.Pdf.Services.HtmlBuilder;
using Caracan.Pdf.Services.HtmlRenderer;
using Caracan.Templates.Manager;

namespace Caracan.Pdf.Services.PdfGenerator
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

        public async Task<Stream> CreatePdfAsync<TLiquidData>(TLiquidData data, CaracanPdfOptions options)
            where TLiquidData : class
        {
            //todo: templateObject file name passed from higher level, not hardcoded. 
            const string templateFileName = "template.liquid2";
            var boundTemplate = await _templateManager.GetTemplateAndBind(templateFileName, data);

            //unused yet, but might be a right direction for fluent building HTML, appending charts and stuff.
            //alternatively charts might need un-processed fluid templateObject for some reason so that would need some refactor.
            var html = _htmlBuilder.WithTemplate(boundTemplate)
                .AddCharts(null)
                .GetHtml();

            //renders HTML to Stream
            var pdfStream = await _renderer.RenderHtmlToPdfAsync(html, options);

            return pdfStream;
        }
    }
}