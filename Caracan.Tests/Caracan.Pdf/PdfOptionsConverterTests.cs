using System.Collections.Generic;
using System.Linq;
using AutoFixture.Xunit2;
using Caracan.Pdf.Configuration;
using Caracan.Pdf.Converters;
using FluentAssertions;
using Xunit;

namespace Caracan.Tests.Caracan.Pdf
{
    public class PdfOptionsConverterTests
    {
        [Theory]
        [AutoData]
        public void Should_ReturnValidPdfOptionsObject(CaracanPdfOptions pdfOptions)
        {
            // Arrange
            // TODO: Do sth with that properties.
            var omittedProperties = new List<string>
            {
                "Format", "MarginOptions"
            };
            var sut = new PdfOptionsConverter();
            
            // Act
            var res = sut.Convert(pdfOptions);
            
            // Assert
            var dstProperties = res.GetType()
                                   .GetProperties()
                                   .Where(x => !omittedProperties.Contains(x.Name));
            
            foreach (var dstProperty in dstProperties)
            {
                var srcPropertyValue = pdfOptions.GetType()
                                                 .GetProperty(dstProperty.Name)
                                                 .GetValue(pdfOptions, null);

                dstProperty.GetValue(res, null).Should().Be(srcPropertyValue);
            }
        }
    }
}