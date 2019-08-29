using System.IO;
using System.Threading.Tasks;

namespace Caracan.Pdf.Services
{
    public interface IHtmlRenderer
    {
        /// <summary>
        /// Renders HTML To Pdf thanks to Chrome
        /// </summary>
        /// <param name="html"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<Stream> RenderHtmlToPdfAsync(string html, Configuration.CaracanPdfOptions options);
        
        /// <summary>
        /// Renders HTML To Pdf from url by fetch thanks to Chrome
        /// </summary>
        /// <param name="url"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<Stream> RenderPdfFromUrlAsync(string url, Configuration.CaracanPdfOptions options);
    }
}
