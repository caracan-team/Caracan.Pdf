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
            // Arrange
            var labels = new List<string> { "A", "B" };
            // Act
            var chart = _sut.Bar().AddLabels(labels).Build();
            //Assert
            chart.Type.Should().Be(ChartType.Bar);
            chart.Data.Labels.Should().HaveCount(2);
        }
    }
}
