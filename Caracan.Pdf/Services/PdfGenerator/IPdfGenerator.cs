using System.IO;
using System.Threading.Tasks;

namespace Caracan.Pdf.Services.IPdfGenerator
{
    public interface IPdfGenerator
    {
        Task<Stream> CreatePdfAsync(Configuration.CaracanPdfOptions options);
    }
}