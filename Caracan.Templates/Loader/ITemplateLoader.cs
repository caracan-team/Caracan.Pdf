using System.Threading.Tasks;

namespace Caracan.Templates.Loader
{
    public interface ITemplateLoader
    {
        Task<string> GetTemplateAsync(string fileName);
    }
}