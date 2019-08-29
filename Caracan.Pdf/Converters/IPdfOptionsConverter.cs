using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caracan.Pdf.Converters
{
    public interface IPdfOptionsConverter
    {
        PdfOptions Convert(Configuration.CaracanPdfOptions pdfOptions);
    }
}
