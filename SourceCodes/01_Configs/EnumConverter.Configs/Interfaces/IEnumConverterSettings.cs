using System;

namespace Aliencube.EnumConverter.Configs.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>EnumConverterSettings</c> class.
    /// </summary>
    public interface IEnumConverterSettings : IDisposable
    {
        /// <summary>
        /// Gets or sets the product element.
        /// </summary>
        ProductElement Product { get; set; }
    }
}