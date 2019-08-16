using PuppeteerSharp;

namespace Caracan.Pdf.Converters
{
    public class PdfOptionsConverter : IPdfOptionsConverter
    {
        public PdfOptions Convert(Configuration.PdfOptions pdfOptions)
        {
            return new PdfOptions
            {
                Height = pdfOptions.Height,
                Width = pdfOptions.Width,
                PageRanges = pdfOptions.PageRanges,
                Landscape = pdfOptions.Landscape,
                PreferCSSPageSize = pdfOptions.PreferCSSPageSize,
                PrintBackground = pdfOptions.PrintBackground,
                FooterTemplate = pdfOptions.FooterTemplate,
                HeaderTemplate = pdfOptions.HeaderTemplate,
                DisplayHeaderFooter = pdfOptions.DisplayHeaderFooter,
                Scale = pdfOptions.Scale,

            };
        }
    }
}
