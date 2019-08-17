using Caracan.Charts.Models;
using System.Collections.Generic;

namespace Caracan.Charts.Builders
{
    public class ChartBuilder : IChartBuilder
    {
        private readonly Chart _chart = new Chart();

        public IChartBuilder AddLabels(List<string> labels)
        {
            if (_chart.Data is null)
                _chart.Data = new Data();

            _chart.Data.Labels.AddRange(labels);

            return this;
        }

        public IChartBuilder ShowArea()
        {
            if (_chart.Options is null)
                _chart.Options = new Options();
            _chart.Options.ShowArea = true;

            return this;
        }
    }
}
