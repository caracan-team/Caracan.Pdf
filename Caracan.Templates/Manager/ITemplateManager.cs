using System.Threading.Tasks;

namespace Caracan.Templates.Manager
{
    public interface ITemplateManager
    {
        /// <summary>
        /// Returns bound templateObject for given name with given liquid object data
        /// </summary>
        /// <param name="templateFileName"></param>
        /// <param name="liquidTemplateObjectData"></param>
        /// <returns></returns>
        Task<string> GetTemplateAndBind(string templateFileName, object liquidTemplateObjectData);
        
    }
}