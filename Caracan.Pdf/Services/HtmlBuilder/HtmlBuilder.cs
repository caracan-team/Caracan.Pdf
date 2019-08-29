using System.Text;

namespace Caracan.Pdf.Services.HtmlBuilder
{
    public class HtmlBuilder : IHtmlBuilder
    {
        private StringBuilder _sb = new StringBuilder();
        public IHtmlBuilder WithTemplate(string template)
        {
            if (!string.IsNullOrEmpty(template))
                _sb = _sb.Append(template);

            return this;
        }

        public IHtmlBuilder AddCharts(string chartHtml)
        {
            if (!string.IsNullOrEmpty(chartHtml))
                _sb = _sb.Append(chartHtml);
            return this;
        }

        public string GetHtml()
        {
            return _sb.ToString();
        }


    }
}