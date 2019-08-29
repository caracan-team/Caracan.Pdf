using System.Threading.Tasks;
using Caracan.Templates;

namespace Caracan.Liquid
{
    public interface ITemplateManager
    {
        /// <summary>
        /// Returns bound template for given name with given liquid object data
        /// </summary>
        /// <param name="templateFileName"></param>
        /// <param name="liquidTemplateData"></param>
        /// <returns></returns>
        Task<string> GetTemplateAndBind(string templateFileName, ILiquidTemplate liquidTemplateData);
    }
}