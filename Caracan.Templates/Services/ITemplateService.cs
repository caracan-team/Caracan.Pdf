using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Caracan.Templates.Services
{
    public interface ITemplateService
    {
        string RenderTemplate<T>(string template, T model);
    }
}
