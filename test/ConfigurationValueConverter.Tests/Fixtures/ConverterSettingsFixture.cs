using System;

using Aliencube.ConfigurationValueConverter.Configs.Interfaces;

namespace Aliencube.ConfigurationValueConverter.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for the <see cref="ConverterSettingsTest"/> class.
    /// </summary>
    public class ConverterSettingsFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Initialises a new instance of the <see cref="ConverterSettingsFixture"/> class.
        /// </summary>
        public ConverterSettingsFixture()
        {
            this.ConverterSettings = Configs.ConverterSettings.CreateInstance();
        }

        /// <summary>
        /// Gets the <see cref="IConverterSettings"/> instance.
        /// </summary>
        public IConverterSettings ConverterSettings { get; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}