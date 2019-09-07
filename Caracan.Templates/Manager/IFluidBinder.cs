using System.Threading.Tasks;

namespace Caracan.Templates.Manager
{
    public interface IFluidBinder
    {
        /// <summary>
        /// Returns bound templateObject for given name with given liquid object data
        /// </summary>
        /// <param name="fluidTemplate"></param>
        /// <param name="liquidTemplateObjectData"></param>
        /// <returns></returns>
        Task<string> Bind(string fluidTemplate, object liquidTemplateObjectData);
        
    }
}