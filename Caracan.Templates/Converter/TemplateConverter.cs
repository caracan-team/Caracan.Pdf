using System.Collections.Generic;
using Newtonsoft.Json;

namespace Caracan.Templates
{
    public class TemplateConverter : ITemplateConverter
    {
        public Dictionary<string, object> Convert<T>(T template) where T : class, ILiquidTemplate
        {
            var json = JsonConvert.SerializeObject(template);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            return dictionary;
        }
    }
}