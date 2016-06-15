using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

using Aliencube.ConfigurationValueConverter.Interfaces;
using Aliencube.ConfigurationValueConverter.Tests.Fixtures;

using FluentAssertions;

using Moq;

using Xunit;

namespace Aliencube.ConfigurationValueConverter.Tests
{
    /// <summary>
    /// This represents the test entity for the <see cref="CommaDelimitedListConverter{TEnum}"/> class.
    /// </summary>
    public class CommaDelimitedListConverterTest : IClassFixture<CommaDelimitedListConverterFixture>
    {
        private readonly ICommaDelimitedListConverter _converter;
        private readonly Mock<ITypeDescriptorContext> _context;
        private readonly CultureInfo _culture;

        /// <summary>
        /// Initialises a new instance of the <see cref="CommaDelimitedListConverterTest"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="CommaDelimitedListConverterFixture"/> instance.</param>
        public CommaDelimitedListConverterTest(CommaDelimitedListConverterFixture fixture)
        {
            this._converter = fixture.CommaDelimitedListConverter;
            this._context = fixture.TypeDescriptorContext;
            this._culture = fixture.CultureInfo;
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        /// <param name="type">Type of enum.</param>
        /// <param name="expected">Value expected.</param>
        [Theory]
        [InlineData(typeof(int), true)]
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

        [Theory]
        [InlineData("1,2,3")]
        public void GetConverted_GivenIntegerValue_ReturnConverted(string value)
        {
            var expected = value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => Convert.ToInt32(p.Trim())).ToList();
            var result = this._converter.ConvertFrom(this._context.Object, this._culture, value) as List<int>;
            result.Should().NotBeNull();
            result.Should().BeOfType<List<int>>();
            result.Should().HaveCount(expected.Count);
            for (var i = 0; i < expected.Count; i++)
            {
                result[i].Should().Be(expected[i]);
            }
        }
    }
}