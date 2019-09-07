using System.IO;
using System.Threading.Tasks;
using Caracan.Pdf.Configuration;
using Caracan.Pdf.Services.HtmlBuilder;

namespace Caracan.Pdf.Services.PdfGenerator
{
    class CaracanPdfGenerator : ICaracanPdfGenerator
    {
        private readonly IReportBuilder _reportBuilder;

        public CaracanPdfGenerator(IReportBuilder reportBuilder)
        {
            _reportBuilder = reportBuilder;
        }

        public async Task<Stream> CreatePdfAsync<TLiquidData>(TLiquidData data, CaracanPdfOptions options)
            where TLiquidData : class
        {
            var stream = _reportBuilder
                .AddDefaultTemplate()
                .WithData(data)
                .WithOptions(options)
                .AddCharts(null)
                .ToStream();

            return stream;
        }
    }
}