using System.Threading.Tasks;

namespace Caracan.Templates
{
    public interface ITemplateLoader
    {
        Task<string> GetTemplateAsync(string fileName);
    }
}