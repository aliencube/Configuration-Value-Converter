using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Aliencube.ConfigurationConverters;
using Aliencube.ConfigurationConverters.Interfaces;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Aliencube.ConfigurationConverter.Tests
{
    [TestFixture]
    public class ListConverterTest
    {
        private ICommaDelimitedListConverter _converter;
        private ITypeDescriptorContext _context;
        private CultureInfo _culture;

        [SetUp]
        public void Init()
        {
            this._context = Substitute.For<ITypeDescriptorContext>();
            this._culture = CultureInfo.InvariantCulture;
        }

        [TearDown]
        public void Cleanup()
        {
            if (this._converter != null)
            {
                this._converter.Dispose();
            }
        }

        [Test]
        [TestCase(typeof(int), true)]
        [TestCase(typeof(string), true)]
        [TestCase(typeof(TestEnum), true)]
        public void CanConvertFrom_GivenType_ReturnValue(Type type, bool expected)
        {
            if (type == typeof(int))
            {
                this._converter = new CommaDelimitedListConverter<int>();
            }
            else if (type == typeof(string))
            {
                this._converter = new CommaDelimitedListConverter<string>();
            }
            else if (type == typeof (TestEnum))
            {
                this._converter = new CommaDelimitedListConverter<TestEnum>();
            }

            var result = this._converter.CanConvertFrom(this._context, type);
            result.Should().Be(expected);
        }

        [Test]
        [TestCase("1,2,3", null)]
        [TestCase("", null)]
        [TestCase(null, typeof(ArgumentNullException))]
        public void GetConverted_GivenIntegerValue_ReturnConverted(string value, Type exceptionType)
        {
            this._converter = new CommaDelimitedListConverter<int>();

            if (exceptionType != null)
            {
                Action action = () => this._converter.ConvertFrom(this._context, this._culture, value);

                if (exceptionType == typeof(ArgumentNullException))
                {
                    action.ShouldThrow<ArgumentNullException>();
                }

                return;
            }

            var expected = value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => Convert.ToInt32(p.Trim())).ToList();
            var result = this._converter.ConvertFrom(this._context, this._culture, value) as List<int>;
            result.Should().NotBeNull();
            result.Should().BeOfType<List<int>>();
            result.Should().HaveCount(expected.Count);
            for (var i = 0; i < expected.Count; i++)
            {
                result[i].Should().Be(expected[i]);
            }
        }

        [Test]
        [TestCase("gif,jpg,png", null)]
        [TestCase("", null)]
        [TestCase(null, typeof(ArgumentNullException))]
        public void GetConverted_GivenStringValue_ReturnConverted(string value, Type exceptionType)
        {
            this._converter = new CommaDelimitedListConverter<string>();

            if (exceptionType != null)
            {
                Action action = () => this._converter.ConvertFrom(this._context, this._culture, value);

                if (exceptionType == typeof(ArgumentNullException))
                {
                    action.ShouldThrow<ArgumentNullException>();
                }

                return;
            }

            var expected = value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
            var result = this._converter.ConvertFrom(this._context, this._culture, value) as List<string>;
            result.Should().NotBeNull();
            result.Should().BeOfType<List<string>>();
            result.Should().HaveCount(expected.Count);
            for (var i = 0; i < expected.Count; i++)
            {
                result[i].Should().Be(expected[i]);
            }
        }

        [Test]
        [TestCase("Test0,Test1,Test2", null)]
        [TestCase("", null)]
        [TestCase(null, typeof(ArgumentNullException))]
        public void GetConverted_GivenEnumValue_ReturnConverted(string value, Type exceptionType)
        {
            this._converter = new CommaDelimitedListConverter<TestEnum>();

            if (exceptionType != null)
            {
                Action action = () => this._converter.ConvertFrom(this._context, this._culture, value);

                if (exceptionType == typeof(ArgumentNullException))
                {
                    action.ShouldThrow<ArgumentNullException>();
                }

                return;
            }

            var expected = value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => (TestEnum)Enum.Parse(typeof(TestEnum), p.Trim(), true)).ToList();
            var result = this._converter.ConvertFrom(this._context, this._culture, value) as List<TestEnum>;
            result.Should().NotBeNull();
            result.Should().BeOfType<List<TestEnum>>();
            result.Should().HaveCount(expected.Count);
            for (var i = 0; i < expected.Count; i++)
            {
                result[i].Should().Be(expected[i]);
            }
        }
    }
}