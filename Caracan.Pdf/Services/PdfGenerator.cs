using System;
using System.IO;
using System.Threading.Tasks;
using Caracan.Pdf.Configuration;
using Caracan.Pdf.Converters;
using Microsoft.Extensions.Options;
using PuppeteerSharp;

namespace Caracan.Pdf.Services
{
    public class PdfGenerator : IPdfGenerator
    {
        private readonly PdfGeneratorOptions _pdfGeneratorOptions;
        private readonly IPdfOptionsConverter _converter;

        public PdfGenerator(IOptions<PdfGeneratorOptions> options, IPdfOptionsConverter converter)
        {
            _pdfGeneratorOptions = options.Value;
            _converter = converter;
        }

        public async Task<Stream> CreatePdfAsync(string html, Configuration.PdfOptions pdfOptions)
        {
            using (var browser = await Puppeteer.ConnectAsync(GetConnectionOptions()))
            {
                using (var page = await browser.NewPageAsync())
                {
                    await page.SetContentAsync(html);
                    await page.SetCacheEnabledAsync(false);
                    var result = await page.GetContentAsync();
                    return await page.PdfStreamAsync(_converter.Convert(pdfOptions));
                }
            }
        }

        private ConnectOptions GetConnectionOptions()
        {
            return new ConnectOptions()
            {
                BrowserWSEndpoint = _pdfGeneratorOptions.Connection
            };
        }
    }
}
