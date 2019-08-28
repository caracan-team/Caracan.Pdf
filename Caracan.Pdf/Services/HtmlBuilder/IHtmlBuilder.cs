using System.Threading.Tasks;
using Caracan.Templates;

namespace Caracan.Pdf.Services.HtmlBuilder
{
    public interface IHtmlBuilder
    {
        IHtmlBuilder WithHtml(string initHtml, ILiquidTemplate templateBindObject);
        IHtmlBuilder AddCharts(string chartHtml);
        string GetHtml();
    }
}