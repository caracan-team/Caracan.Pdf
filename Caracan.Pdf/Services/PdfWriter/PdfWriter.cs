using System;
using System.IO;
using Caracan.Pdf.Exceptions;

namespace Caracan.Pdf.Services
{
    /// <summary>
    /// This class is rather for debugging purposes.
    /// </summary>
    public class PdfWriter : IPdfWriter
    {
        public void RenderStreamToPdf(Stream input, string name)
        {
            try
            {
                var path = Directory.GetCurrentDirectory();
                var fullDestPath = Path.Combine(path, $"{name}.pdf");
                
                using (var fileStream = new FileStream(fullDestPath, FileMode.Create, FileAccess.Write))
                {
                    input.CopyTo(fileStream);
                }
            }
            catch (Exception exception)
            {
                throw new FailedToRenderPdfCaracanException($"Failed to render pdf of name '{name}'.", exception);
            }
        }
    }
}