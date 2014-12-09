using System.Configuration;
using Aliencube.EnumConverter.Configs.Interfaces;

namespace Aliencube.EnumConverter.Configs
{
    /// <summary>
    /// This represents the <c>ConfigurationSection</c> entity defined in either App.config or Web.config.
    /// </summary>
    public class EnumConverterSettings : ConfigurationSection, IEnumConverterSettings
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
        /// Creates a new instance of the <c>EnumConverterSettings</c> class.
        /// </summary>
        /// <returns>Returns the new instance of the <c>EnumConverterSettings</c> class.</returns>
        public static IEnumConverterSettings CreateInstance()
        {
            var settings = ConfigurationManager.GetSection("enumConverterSettings") as IEnumConverterSettings;
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