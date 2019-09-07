using System.Threading.Tasks;
using Fluid;
using Newtonsoft.Json.Linq;

namespace Caracan.Templates.Manager
{
    public class FluidBinder : IFluidBinder
    {
        public async Task<string> Bind(string fluidTemplate, object liquidTemplateObject)
        {
            var renderedTemplate = FluidTemplate.Parse(fluidTemplate);
            var context = new TemplateContext();

            context.SetValue("report", JObject.FromObject(liquidTemplateObject));
            //todo: figure out better way of indicating model's properties. (dynamically or by convention, as currently it's hardcoded "collection")

            var rendered = renderedTemplate.Render(context);
            return rendered;
        }
    }
}