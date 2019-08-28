using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Caracan.Pdf.Configuration;
using Caracan.Pdf.Converters;
using Microsoft.Extensions.Options;
using PuppeteerSharp;

namespace Caracan.Pdf.Services
{
    public class HtmlRenderer : IHtmlRenderer
    {
        private readonly PdfGeneratorOptions _pdfGeneratorOptions;
        private readonly IPdfOptionsConverter _converter;

        public HtmlRenderer(PdfGeneratorOptions options, IPdfOptionsConverter converter)
        {
            _pdfGeneratorOptions = options;
            _converter = converter;
        }

        public async Task<Stream> RenderPdfAsync(string html, Configuration.PdfOptions pdfOptions)
        {
            using (var browser = await Puppeteer.ConnectAsync(GetConnectionOptions()))
            using (var page = await browser.NewPageAsync())
            {
                //there goes logic that will be responsible for manipulation of html
                
                await Task.WhenAll(page.SetContentAsync(html), 
                                   page.SetCacheEnabledAsync(false));
                
                return await page.PdfStreamAsync(_converter.Convert(pdfOptions));
            }
        }

        public async Task<Stream> RenderPdfFromUrlAsync(string url, Configuration.PdfOptions pdfOptions)
        {
            using (var browser = await Puppeteer.ConnectAsync(GetConnectionOptions()))
            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync(url);

                return await page.PdfStreamAsync(_converter.Convert(pdfOptions));
            }
        }

        private ConnectOptions GetConnectionOptions()
        {
            return new ConnectOptions
            {
                BrowserWSEndpoint = _pdfGeneratorOptions.Connection.StartsWith("wss://") ||
                                    _pdfGeneratorOptions.Connection.StartsWith("ws://")
                    ? _pdfGeneratorOptions.Connection
                    : $"wss://{_pdfGeneratorOptions.Connection}"
            };
        }
    }
}
