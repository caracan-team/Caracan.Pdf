using System.IO;
using System.Threading.Tasks;

namespace Caracan.Pdf.Services.PdfGenerator
{
    public interface ICaracanPdfGenerator
    {
        Task<Stream> CreatePdfAsync<TLiquidData>(TLiquidData data, Configuration.CaracanPdfOptions options)
            where TLiquidData : class;
    }
}