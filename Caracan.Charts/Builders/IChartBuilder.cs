using System;
using System.Collections.Generic;
using System.Text;

namespace Caracan.Charts.Builders
{
    public interface IChartBuilder
    {
        IChartBuilder AddLabels(List<string> labels);
        //TODO: we must decide how store series(look at chartist docs - several posibilities of the series format)
        //IChartBuilder AddSeries();

        IChartBuilder ShowArea();
        //TODO: etc

    }
}
