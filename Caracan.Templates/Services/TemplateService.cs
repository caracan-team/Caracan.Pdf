using Fluid;
using System;

namespace Caracan.Templates.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly string _name = "model";

        public string RenderTemplate<T>(string source, T model)
        {
            if (FluidTemplate.TryParse(source, out var template))
            {
                var context = new TemplateContext();
                context.MemberAccessStrategy.Register(model.GetType());
                context.SetValue(_name, model);

                return template.Render(context);
            }
            return String.Empty;
        }
    }
}
