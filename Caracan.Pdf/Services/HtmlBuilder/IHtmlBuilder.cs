namespace Caracan.Pdf.Services.HtmlBuilder
{
    public interface IHtmlBuilder
    {
        IHtmlBuilder WithTemplate(string template);
        IHtmlBuilder AddCharts(string chartHtml);
        string GetHtml();
    }
}