using System.IO;
using System.Threading.Tasks;

namespace Caracan.Pdf.Services
{
    public interface IHtmlRenderer
    {
        Task<Stream> RenderPdfAsync(string html, Configuration.PdfOptions options);
        Task<Stream> RenderPdfFromUrlAsync(string url, Configuration.PdfOptions options);
    }
}
