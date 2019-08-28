using System.Threading.Tasks;

namespace Caracan.Pdf.Services.HtmlBuilder
{
    public interface IHtmlBuilder
    {
        IHtmlBuilder WithHtml(string initHtml);
        IHtmlBuilder AddCharts(string tbaOption);
        string GetHtml();
    }
}