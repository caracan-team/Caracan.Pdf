using System.Collections.Generic;
using Newtonsoft.Json;

namespace Caracan.Templates
{
    public static class LiquidBindedObjectExtensions
    {
        public static Dictionary<string, object> ToDictionary(this ILiquidTemplate template)
        {
            var json = JsonConvert.SerializeObject(template);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            return dictionary;
        }
    }
}