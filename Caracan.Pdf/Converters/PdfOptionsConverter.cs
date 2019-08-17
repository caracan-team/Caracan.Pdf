using PuppeteerSharp;

namespace Caracan.Pdf.Converters
{
    public class PdfOptionsConverter : IPdfOptionsConverter
    {
        public PdfOptions Convert(Configuration.PdfOptions pdfOptions)
        {
            return new PdfOptions
            {
                Scale = pdfOptions.Scale,
                DisplayHeaderFooter = pdfOptions.DisplayHeaderFooter,
                HeaderTemplate = pdfOptions.HeaderTemplate,
                FooterTemplate = pdfOptions.FooterTemplate,
                PrintBackground = pdfOptions.PrintBackground,
                Landscape = pdfOptions.Landscape,
                PageRanges = pdfOptions.PageRanges,
                //Format = pdfOptions.Format,
                Width = pdfOptions.Width,
                Height = pdfOptions.Height,
                //MarginOptions = pdfOptions.MarginOptions,
                PreferCSSPageSize = pdfOptions.PreferCSSPageSize
            };
        }
    }
}
