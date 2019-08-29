using System.IO;
using System.Threading.Tasks;

namespace Caracan.Pdf.Services
{
    /// <summary>
    /// This class is rather for debugging purposes.
    /// </summary>
    public interface IPdfWriter
    {
        void RenderStreamToPdf(Stream input, string name);
    }
}