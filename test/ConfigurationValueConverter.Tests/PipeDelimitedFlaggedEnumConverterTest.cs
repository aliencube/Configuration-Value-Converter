using System;
using System.ComponentModel;
using System.Globalization;

using Aliencube.ConfigurationValueConverter.Configs;
using Aliencube.ConfigurationValueConverter.Interfaces;
using Aliencube.ConfigurationValueConverter.Tests.Fixtures;

using FluentAssertions;

using Moq;

using Xunit;

namespace Aliencube.ConfigurationValueConverter.Tests
{
    /// <summary>
    /// This represents the test entity for the <see cref="PipeDelimitedFlaggedEnumConverter{TEnum}"/> class.
    /// </summary>
    public class PipeDelimitedFlaggedEnumConverterTest : IClassFixture<PipeDelimitedFlaggedEnumConverterFixture>
    {
        private readonly IPipeDelimitedFlaggedEnumConverter _converter;
        private readonly Mock<ITypeDescriptorContext> _context;
        private readonly CultureInfo _culture;

        /// <summary>
        /// Initialises a new instance of the <see cref="PipeDelimitedFlaggedEnumConverterTest"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="CommaDelimitedListConverterFixture"/> instance.</param>
        public PipeDelimitedFlaggedEnumConverterTest(PipeDelimitedFlaggedEnumConverterFixture fixture)
        {
            this._converter = fixture.PipeDelimitedFlaggedEnumConverter;
            this._context = fixture.TypeDescriptorContext;
            this._culture = fixture.CultureInfo;
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        /// <param name="type">Type of enum.</param>
        /// <param name="expected">Value expected.</param>
        [Theory]
        [InlineData(typeof(ProductTypes), true)]
        public void Given_Parameters_CanConvertFrom_ShouldReturn_Result(Type type, bool expected)
        {
            var result = this._converter.CanConvertFrom(this._context.Object, type);
            result.Should().Be(expected);
        }

        /// <summary>
        /// Tests whether the method should throw an exception or not.
        /// </summary>
        [Fact]
        public void Given_NullParameter_ConvertFrom_ShouldThrow_Exception()
        {
            Action action = () => { var result = this._converter.ConvertFrom(this._context.Object, this._culture, null); };
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="expected">Value expected.</param>
        [Theory]
        [InlineData("ProductA|ProductB|ProductC", ProductTypes.ProductA)]
        [InlineData("ProductA|ProductB|ProductC", ProductTypes.ProductB)]
        [InlineData("ProductA|ProductB|ProductC", ProductTypes.ProductC)]
        public void Given_Parameters_ConvertFrom_ShouldReturn_Result(string value, ProductTypes expected)
        {
            var result = (ProductTypes)this._converter.ConvertFrom(this._context.Object, this._culture, value);
            result.Should().HaveFlag(expected);
        }
    }
}