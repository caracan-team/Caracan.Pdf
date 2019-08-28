using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Caracan.Liquid;
using DotLiquid;

namespace Caracan.Templates
{
    public class TemplateManager : ITemplateManager
    {
        public Template ParseTemplate(string html)
        {
            return Template.Parse(html);
        }

        public string RenderTemplate(Template template, Dictionary<string, object> templateProperties)
        {
            var rendered = template.Render(Hash.FromDictionary(templateProperties));
            return rendered;
        }
        
    }
}