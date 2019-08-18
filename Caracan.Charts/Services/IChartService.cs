using Caracan.Charts.Models;

namespace Caracan.Charts.Services
{
    public interface IChartService
    {
        string RenderJavaScript(Chart chart);
        string RenderHtml(Chart chart);
    }
}
