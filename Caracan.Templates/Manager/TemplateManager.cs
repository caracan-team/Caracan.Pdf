using System.Threading.Tasks;
using Caracan.Templates.Loader;
using Fluid;
using Newtonsoft.Json.Linq;

namespace Caracan.Templates.Manager
{
    public class TemplateManager : ITemplateManager
    {
        private readonly ITemplateLoader _templateLoader;

        public TemplateManager(ITemplateLoader templateLoader)
        {
            _templateLoader = templateLoader;
        }

        public async Task<string> GetTemplateAndBind(string templateFileName, object liquidTemplateObject)
        {
            var template = await _templateLoader.GetTemplateAsync(templateFileName);
            var rendered = await BindTemplateAsync(template, liquidTemplateObject);

            return rendered;
        }

        private async Task<string> BindTemplateAsync(string template, object liquidTemplateObject)
        {
            var fluidTemplate = FluidTemplate.Parse(template);
            var context = new TemplateContext();

            context.SetValue("report", JObject.FromObject(liquidTemplateObject));
            //todo: figure out better way of indicating model's properties. (dynamically or by convention, as currently it's hardcoded "collection")

            var rendered = fluidTemplate.Render(context);
            return rendered;
        }
        
    }
}