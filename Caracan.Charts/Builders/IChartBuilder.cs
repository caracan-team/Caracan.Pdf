using Caracan.Charts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caracan.Charts.Builders
{
    public interface IChartBuilder
    {
        IChartBuilder Line();
        IChartBuilder Pie();
        IChartBuilder Bar();

        IChartBuilder AddLabels(List<string> labels);
        //TODO: we must decide how store series(look at chartist docs - several posibilities of the series format)
        //IChartBuilder AddSeries();

        IChartBuilder AddOptions(Options options);
        IChartBuilder AddName(string name);
        Chart Build();
    }
}
