using System;
using System.IO;
using Caracan.Pdf.Services;

namespace Caracan.Pdf.Extensions
{
    public static class PdfWriterExtensions
    {
        public static void RenderOrOmit(this IPdfWriter pdfWriter, Stream pdfStream, bool renderPdfCurrentDirectory)
        {
            if (renderPdfCurrentDirectory)
            {
                pdfWriter.RenderStreamToPdf(pdfStream,
                    $"caracan_{DateTime.UtcNow:yyy-MM-dd-hh.mm.ss}_{new Random().Next()}");
            }
        }
    }
}