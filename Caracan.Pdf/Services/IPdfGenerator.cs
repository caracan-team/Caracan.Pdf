using System.IO;
using System.Threading.Tasks;

namespace Caracan.Pdf.Services
{
    public interface IPdfGenerator
    {
        Task<Stream> CreatePdfAsync(string html, Configuration.PdfOptions options);
        Task<Stream> CreatePdfFromUrlAsync(string url, Configuration.PdfOptions options);
    }
}
