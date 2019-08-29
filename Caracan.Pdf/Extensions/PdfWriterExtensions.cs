using System;
using System.IO;
using Caracan.Pdf.Exceptions;

namespace Caracan.Pdf.Extensions
{
    public static class StreamExtensions
    {
        public static void ToPdf(this Stream pdfStream)
        {
            var name = string.Empty;
            try
            {
                name = $"caracan_{DateTime.UtcNow:yyy-MM-dd-hh.mm.ss}_{new Random().Next()}";
                var path = Directory.GetCurrentDirectory();
                var fullDestPath = Path.Combine(path, $"{name}.pdf");

                using (var fileStream = new FileStream(fullDestPath, FileMode.Create, FileAccess.Write))
                {
                    pdfStream.CopyTo(fileStream);
                }
            }
            catch (Exception exception)
            {
                throw new FailedToRenderPdfCaracanException($"Failed to render pdf of name '{name}'.", exception);
            }
        }
    }
}