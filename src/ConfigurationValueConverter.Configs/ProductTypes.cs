using System;

namespace Aliencube.ConfigurationValueConverter.Configs
{
    /// <summary>
    /// This specifies the product types.
    /// </summary>
    [Flags]
    public enum ProductTypes
    {
        /// <summary>
        /// Identifies none.
        /// </summary>
        None = 0,

        /// <summary>
        /// Identifies product A.
        /// </summary>
        ProductA = 1 << 0,

        /// <summary>
        /// Identifies product B.
        /// </summary>
        ProductB = 1 << 1,

        /// <summary>
        /// Identifies product C.
        /// </summary>
        ProductC = 1 << 2,
    }
}