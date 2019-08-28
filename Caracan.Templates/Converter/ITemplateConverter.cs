using System.Collections.Generic;

namespace Caracan.Templates
{
    public interface ITemplateConverter
    {
        Dictionary<string, object> Convert<T>(T template) where T : class, ILiquidTemplate;
    }
}