using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Caracan.Templates.Loader
{
    public class TemplateLoader : ITemplateLoader
    {
        private const string TemplateFolderName = "Templates";

        private string LoadFromFile(string fullPath)
        {
            return File.ReadAllText(fullPath);
        }
        
        private string GetFullPath(string fileName)
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Remove(0, 6);
            return Path.Combine(exePath, TemplateFolderName, fileName);
        }
        
        public async Task<string> GetTemplateAsync(string fileName)
        {
            var path = GetFullPath(fileName);
            var template = LoadFromFile(path);
            return template;
        }
    }
}