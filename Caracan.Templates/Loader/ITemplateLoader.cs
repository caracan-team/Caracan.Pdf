using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Caracan.Templates
{
    public interface ITemplateLoader
    {
        Task<string> GetTemplateAsync(string fileName);
    }
}