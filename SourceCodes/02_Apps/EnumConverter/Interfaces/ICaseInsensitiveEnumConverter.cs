using System;
using System.ComponentModel;
using System.Globalization;

namespace Aliencube.EnumConverter.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>CaseInsensitiveEnumConverter</c> class.
    /// </summary>
    public interface ICaseInsensitiveEnumConverter : IDisposable
    {
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="ctx"><c>ITypeDescriptorContext</c> that provides a format context.</param>
        /// <param name="type"><c>Type</c> that represents the type you want to convert from.</param>
        /// <returns>Returns <c>True</c>, if this converter can perform the conversion; otherwise returns <c>False</c>.</returns>
        bool CanConvertFrom(ITypeDescriptorContext ctx, Type type);

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context"><c>ITypeDescriptorContext</c> that provides a format context.</param>
        /// <param name="culture"><c>CultureInfo</c> to use as the current culture.</param>
        /// <param name="value"><c>Object</c> to convert.</param>
        /// <returns>Returns the <c>Object</c> that represents the converted value.</returns>
        object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value);
    }
}