using System;
using System.Threading.Tasks;

namespace Caracan.Liquid
{
    public class TemplateManager : ITemplateManager
    {
        public async Task<string> GetTemplateAsync()
        {
            await Task.CompletedTask;
            // providing mock base html template
            return "<ul>\n{% for item in user.tasks -%}\n  <li>{{ item.name }}</li>\n{% endfor -%}\n</ul>"; 
        }
    }
}