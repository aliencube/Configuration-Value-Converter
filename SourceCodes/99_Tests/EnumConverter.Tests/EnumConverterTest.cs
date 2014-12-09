using System;
using System.ComponentModel;
using System.Globalization;
using Aliencube.EnumConverter.Interfaces;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Aliencube.EnumConverter.Tests
{
    [TestFixture]
    public class EnumConverterTest
    {
        private ICaseInsensitiveEnumConverter _converter;
        private ITypeDescriptorContext _context;
        private CultureInfo _culture;

        [SetUp]
        public void Init()
        {
            this._converter = new CaseInsensitiveEnumConverter<TestEnum>();
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
        [TestCase(typeof(TestEnum), true)]
        public void CanConvertFrom_GivenType_ReturnValue(Type type, bool expected)
        {
            var result = this._converter.CanConvertFrom(this._context, type);
            result.Should().Be(expected);
        }

        [Test]
        [TestCase("test0", TestEnum.Test0, null)]
        [TestCase(null, null, typeof(ArgumentNullException))]
        [TestCase("test10", null, typeof(InvalidOperationException))]
        public void GetConverted_GivenValue_ReturnConverted(string value, TestEnum expected, Type exceptionType)
        {
            if (exceptionType != null)
            {
                Action action = () => this._converter.ConvertFrom(this._context, this._culture, value);

                if (exceptionType == typeof(ArgumentNullException))
                {
                    action.ShouldThrow<ArgumentNullException>();
                }
                else if (exceptionType == typeof(InvalidOperationException))
                {
                    action.ShouldThrow<InvalidOperationException>();
                }

                return;
            }

            var result = this._converter.ConvertFrom(this._context, this._culture, value);
            result.Should().Be(expected);
        }
    }
}