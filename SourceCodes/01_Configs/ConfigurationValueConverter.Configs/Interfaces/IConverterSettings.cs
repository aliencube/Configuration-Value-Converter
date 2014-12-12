using System;

namespace Aliencube.ConfigurationValueConverter.Configs.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>EnumConverterSettings</c> class.
    /// </summary>
    public interface IConverterSettings : IDisposable
    {
        /// <summary>
        /// Gets or sets the product element.
        /// </summary>
        ProductElement Product { get; set; }
    }
}