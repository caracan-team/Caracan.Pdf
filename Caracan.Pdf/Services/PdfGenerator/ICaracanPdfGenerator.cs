using System.IO;
using System.Threading.Tasks;

namespace Caracan.Pdf.Services.IPdfGenerator
{
    public interface ICaracanPdfGenerator
    {
        Task<Stream> CreatePdfAsync(Configuration.CaracanPdfOptions options);
    }
}