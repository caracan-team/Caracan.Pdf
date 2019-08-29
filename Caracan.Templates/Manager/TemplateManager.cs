using System.Threading.Tasks;
using Caracan.Liquid;
using Fluid;

namespace Caracan.Templates
{
    public class TemplateManager : ITemplateManager
    {
        private readonly ITemplateLoader _templateLoader;

        public TemplateManager(ITemplateLoader templateLoader)
        {
            _templateLoader = templateLoader;
        }

        public async Task<string> GetTemplateAndBind(string templateFileName, ILiquidTemplate liquidTemplate)
        {
            var template = await _templateLoader.GetTemplateAsync(templateFileName);
            var rendered = await BindTemplateAsync(template, liquidTemplate);

            return rendered;
        }

        private async Task<string> BindTemplateAsync(string template, ILiquidTemplate liquidTemplate)
        {
            var fluidTemplate = FluidTemplate.Parse(template);
            var context = new TemplateContext();
            context.SetValue("collection", liquidTemplate);
            //todo: figure out better way of indicating model's properties. (dynamically or by convention, as currently it's hardcoded "collection")
            
            var rendered = fluidTemplate.Render(context);
            return rendered;
        }
    }
}