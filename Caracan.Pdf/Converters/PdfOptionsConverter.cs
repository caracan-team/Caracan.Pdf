using Caracan.Pdf.Models;
using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace Caracan.Pdf.Converters
{
    public class PdfOptionsConverter : IPdfOptionsConverter
    {
        public PdfOptions Convert(Configuration.CaracanPdfOptions pdfOptions)
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
                Format = ConvertFormat(pdfOptions.Format),
                Width = pdfOptions.Width,
                Height = pdfOptions.Height,
                MarginOptions = new PuppeteerSharp.Media.MarginOptions {
                    Top = pdfOptions.MarginOptions.Top,
                    Bottom = pdfOptions.MarginOptions.Bottom,
                    Left = pdfOptions.MarginOptions.Left,
                    Right = pdfOptions.MarginOptions.Right
                },
                PreferCSSPageSize = pdfOptions.PreferCSSPageSize
            };
        }

        private PaperFormat ConvertFormat(Format format)
        {
            switch (format.Type)
            {
                case FormatType.A0:
                    return PaperFormat.A0;
                case FormatType.A1:
                    return PaperFormat.A1;
                case FormatType.A2:
                    return PaperFormat.A2;
                case FormatType.A3:
                    return PaperFormat.A3;
                case FormatType.A4:
                    return PaperFormat.A4;
                case FormatType.A5:
                    return PaperFormat.A5;
                case FormatType.A6:
                    return PaperFormat.A6;
                case FormatType.Letter:
                    return PaperFormat.Letter;
                case FormatType.Legal:
                    return PaperFormat.Legal;
                case FormatType.Ledger:
                    return PaperFormat.Ledger;
                case FormatType.Tabloid:
                    return PaperFormat.Tabloid;
                default:
                    return new PaperFormat(format.Width, format.Height);
            }
        }
    }
}
