using System.Collections.Generic;
using System.Threading.Tasks;
using DotLiquid;

namespace Caracan.Liquid
{
    public interface ITemplateManager
    {
        Template ParseTemplate(string html);
        string RenderTemplate(Template template, Dictionary<string, object> templateProperties);
    }
}