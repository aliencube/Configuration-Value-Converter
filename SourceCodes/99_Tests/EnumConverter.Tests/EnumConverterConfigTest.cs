using Aliencube.EnumConverter.Configs;
using Aliencube.EnumConverter.Configs.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace Aliencube.EnumConverter.Tests
{
    [TestFixture]
    public class EnumConverterConfigTest
    {
        private IEnumConverterSettings _settings;

        [SetUp]
        public void Init()
        {
            this._settings = EnumConverterSettings.CreateInstance();
        }

        [TearDown]
        public void Cleanup()
        {
            if (this._settings != null)
            {
                this._settings.Dispose();
            }
        }

        [Test]
        [TestCase(ProductStatus.Active)]
        public void CanConvertFrom_GivenConfig_ReturnValue(ProductStatus status)
        {
            this._settings.Product.Status.Should().Be(status);
        }
    }
}