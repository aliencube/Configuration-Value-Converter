using System.Configuration;
using Aliencube.ConfigurationValueConverter.Configs.Interfaces;

namespace Aliencube.ConfigurationValueConverter.Configs
{
    /// <summary>
    /// This represents the <c>ConverterSettings</c> entity defined in either App.config or Web.config.
    /// </summary>
    public class ConverterSettings : ConfigurationSection, IConverterSettings
    {
        private bool _disposed;

        /// <summary>
        /// Gets or sets the product element.
        /// </summary>
        [ConfigurationProperty("product", IsRequired = true)]
        public ProductElement Product
        {
            get { return (ProductElement)this["product"]; }
            set { this["product"] = value; }
        }

        /// <summary>
        /// Creates a new instance of the <c>ConverterSettings</c> class.
        /// </summary>
        /// <returns>Returns the new instance of the <c>ConverterSettings</c> class.</returns>
        public static IConverterSettings CreateInstance()
        {
            var settings = ConfigurationManager.GetSection("converterSettings") as IConverterSettings;
            return settings;
        }

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