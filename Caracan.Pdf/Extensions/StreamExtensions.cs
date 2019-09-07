using System;
using System.IO;
using Caracan.Pdf.Exceptions;

namespace Caracan.Pdf.Extensions
{
    public static class StreamExtensions
    {
        /// <summary>
        /// Saves Stream as file and returns fileName of created 
        /// </summary>
        /// <param fileName="pdfStream"></param>
        /// <param fileName="fileName"></param>
        /// <param name="pdfStream"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="FailedToRenderPdfCaracanException"></exception>
        public static string ToPdf(this Stream pdfStream)
        {
            var fileName = string.Empty;
            try
            {
                fileName = $"caracan_{DateTime.UtcNow:yyy-MM-dd-hh.mm.ss}_{new Random().Next()}";
                var path = Directory.GetCurrentDirectory();
                var fullDestPath = Path.Combine(path, $"{fileName}.pdf");

                using (var fileStream = new FileStream(fullDestPath, FileMode.Create, FileAccess.Write))
                {
                    pdfStream.CopyTo(fileStream);
                }
            }
            catch (Exception exception)
            {
                throw new FailedToRenderPdfCaracanException($"Failed to render pdf of fileName '{fileName}'.", exception);
            }

            return fileName;
        }
    }
}