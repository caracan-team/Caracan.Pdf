using Caracan.Charts.Models;
using System.Collections.Generic;

namespace Caracan.Charts.Builders
{
    public class ChartBuilder : IChartBuilder
    {
        private readonly Chart _chart = new Chart();

        public ChartBuilder()
        {
            _chart.Data = new Data();
            _chart.Options = new Options();
        }

        public IChartBuilder AddLabels(List<string> labels)
        {

            _chart.Data.Labels.AddRange(labels);

            return this;
        }

        public IChartBuilder AddOptions(Options options)
        {
            _chart.Options = options;
            return this;
        }

        public IChartBuilder Bar()
        {
            _chart.Type = ChartType.Bar;
            return this;
        }

        public Chart Build()
        {

            return _chart;
        }

        public IChartBuilder Line()
        {
            _chart.Type = ChartType.Line;
            return this;
        }

        public IChartBuilder Pie()
        {
            _chart.Type = ChartType.Pie;
            return this;
        }
    }
}
