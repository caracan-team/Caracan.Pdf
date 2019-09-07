using System;
using System.Linq;
using Fluid;
using Fluid.Values;

namespace Caracan.Templates.Extensions
{
    public static class CustomFilters
    {
        public static FluidValue HtmlEncode(FluidValue input, FilterArguments arguments, TemplateContext context)
        {
            var htmlInput = input == null ? null : System.Net.WebUtility.HtmlEncode(input.ToString());
            return new StringValue(htmlInput?.ToLower());
        }

        public static string ToBase64(object input, string directory = null)
        {
            directory = directory ?? AppDomain.CurrentDomain.BaseDirectory;
            byte[] buffer = null;
            var inputAsFilePath = (input as string) ?? string.Empty;
            inputAsFilePath = System.IO.Path.Combine(directory, inputAsFilePath);
            if (!string.IsNullOrEmpty(inputAsFilePath) && System.IO.File.Exists(inputAsFilePath))
            {
                buffer = System.IO.File.ReadAllBytes(inputAsFilePath);
            }
            else if (input is System.Collections.Generic.IEnumerable<byte>)
            {
                var inputAsBytes = input as System.Collections.Generic.IEnumerable<byte>;
                buffer = inputAsBytes.ToArray();
            }
            else
            {
                buffer = System.Text.Encoding.Default.GetBytes(input.ToString());
            }

            if (buffer == null)
                return string.Empty;

            var base64String = Convert.ToBase64String(buffer);
            return base64String;
        }

        public static string ToLocalUri(object input, string directory = null)
        {
            directory = directory ?? AppDomain.CurrentDomain.BaseDirectory;
            var inputAsFilePath = (input as string) ?? string.Empty;
            inputAsFilePath = System.IO.Path.Combine(directory, inputAsFilePath);
            var filePathUri = new Uri(inputAsFilePath);
            return filePathUri.ToString();
        }
    }
}