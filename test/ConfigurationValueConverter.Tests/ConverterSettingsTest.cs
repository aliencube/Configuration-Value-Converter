using Aliencube.ConfigurationValueConverter.Configs;
using Aliencube.ConfigurationValueConverter.Configs.Interfaces;
using Aliencube.ConfigurationValueConverter.Tests.Fixtures;

using FluentAssertions;

using Xunit;

namespace Aliencube.ConfigurationValueConverter.Tests
{
    /// <summary>
    /// This represents the test entity for the <see cref="ConverterSettings"/> class.
    /// </summary>
    public class ConverterSettingsTest : IClassFixture<ConverterSettingsFixture>
    {
        private readonly IConverterSettings _settings;

        /// <summary>
        /// Initialises a new instance of the <see cref="ConverterSettingsTest"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="ConverterSettingsFixture"/> instance.</param>
        public ConverterSettingsTest(ConverterSettingsFixture fixture)
        {
            this._settings = fixture.ConverterSettings;
        }

        [Fact]
        public void Given_AppConfig_Settings_ShouldReturn_Result()
        {
            this._settings.Product.Status.Should().Be(ProductStatus.Active);
            this._settings.Product.ProductIds.Should().Contain(1);
            this._settings.Product.ProductIds.Should().Contain(2);
            this._settings.Product.ProductIds.Should().Contain(3);
            this._settings.Product.Types.Should().HaveFlag(ProductTypes.ProductA);
            this._settings.Product.Types.Should().HaveFlag(ProductTypes.ProductC);
        }
    }
}