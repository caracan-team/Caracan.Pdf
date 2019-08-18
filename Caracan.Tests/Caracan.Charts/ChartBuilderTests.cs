using Caracan.Charts.Builders;
using Caracan.Charts.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Caracan.Tests.Caracan.Charts
{
    public class ChartBuilderTests
    {
        private readonly ChartBuilder _sut = new ChartBuilder();

        [Fact]
        public void Should_ReturnValidChart()
        {
            var labels = new List<string> { "A", "B" };
            var chart = _sut.Bar().AddLabels(labels).Build();

            chart.Type.Should().Be(ChartType.Bar);
            chart.Data.Labels.Should().HaveCount(2);
        }
    }
}
