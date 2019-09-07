using PuppeteerSharp;

namespace Caracan.Pdf.Converters
{
    public interface IPdfOptionsConverter
    {
        PdfOptions Convert(Configuration.CaracanPdfOptions pdfOptions);
    }
}
