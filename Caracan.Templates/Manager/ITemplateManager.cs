using System.Threading.Tasks;
using Caracan.Templates;

namespace Caracan.Liquid
{
    public interface ITemplateManager
    {
        Task<string> GetTemplateAndBind(string templateFileName, ILiquidTemplate liquidTemplateData);
    }
}