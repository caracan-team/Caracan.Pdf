using System.Threading.Tasks;

namespace Caracan.Liquid
{
    public interface ITemplateManager
    {
        Task<string> GetTemplateAsync();
    }
}