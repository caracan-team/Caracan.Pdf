using System.IO;
using System.Text;
using Caracan.Pdf.Configuration;
using Caracan.Pdf.Services.HtmlRenderer;
using Caracan.Templates.Loader;
using Caracan.Templates.Manager;

namespace Caracan.Pdf.Services.HtmlBuilder
{
    public class ReportBuilder : IReportBuilder
    {
        private readonly IHtmlRenderer _renderer;
        private readonly IFluidBinder _fluidBinder;
        private readonly ITemplateLoader _templateLoader;
        private StringBuilder _sb = new StringBuilder();
        private CaracanPdfOptions _options;
        private object _data;
        private const string TemplateFileName = "template.liquid";

        public ReportBuilder(IHtmlRenderer renderer, IFluidBinder fluidBinder, ITemplateLoader templateLoader)
        {
            _renderer = renderer;
            _fluidBinder = fluidBinder;
            _templateLoader = templateLoader;
        }

        public IReportBuilder WithData(object data)
        {
            _data = data;
            return this;
        }

        public IReportBuilder WithOptions(CaracanPdfOptions options)
        {
            _options = options;
            return this;
        }

        public IReportBuilder AddDefaultTemplate()
        {
            //todo: templateObject file name passed from higher level, not hardcoded. 
            var template = _templateLoader.GetTemplateAsync(TemplateFileName)
                .GetAwaiter()
                .GetResult();

            _sb = _sb.Append(template);
            return this;
        }

        public IReportBuilder AddCharts(string chartHtml)
        {
            if (!string.IsNullOrEmpty(chartHtml))
                _sb = _sb.Append(chartHtml);
            return this;
        }


        public Stream ToStream()
        {
            var boundTemplate = _fluidBinder.Bind(_sb.ToString(), _data);

            //renders HTML to Stream
            var pdfStream = _renderer.RenderHtmlToPdfAsync(boundTemplate, _options)
                .GetAwaiter()
                .GetResult();

            return pdfStream;
        }
    }
}