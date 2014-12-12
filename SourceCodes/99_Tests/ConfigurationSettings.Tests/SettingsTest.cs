using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliencube.ConfigurationValueConverter.Configs;
using Aliencube.ConfigurationValueConverter.Configs.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace Aliencube.ConfigurationSettings.Tests
{
    [TestFixture]
    public class SettingsTest
    {
        private IConverterSettings _settings;

        [SetUp]
        public void Init()
        {
            this._settings = ConverterSettings.CreateInstance();
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
        [TestCase(ProductStatus.Active, "1,2,3")]
        public void CanConvertFrom_GivenConfig_ReturnValue(ProductStatus status, string productIds)
        {
            this._settings.Product.Status.Should().Be(status);

            var expected = productIds.Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(p => Convert.ToInt32(p))
                                     .ToList();
            this._settings.Product.ProductIds.Should().BeOfType<List<int>>();
            this._settings.Product.ProductIds.Should().HaveCount(expected.Count);
            for (var i = 0; i < expected.Count; i++)
            {
                this._settings.Product.ProductIds[i].Should().Be(expected[i]);
            }
        }
    }
}
