using System;
using System.ComponentModel;
using System.Globalization;

namespace Aliencube.ConfigurationValueConverter.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <see cref="CaseInsensitiveEnumConverter{TEnum}"/> class.
    /// </summary>
    public interface ICaseInsensitiveEnumConverter : IDisposable
    {
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="ctx"><see cref="ITypeDescriptorContext"/> instance that provides a format context.</param>
        /// <param name="type"><see cref="Type"/> object that represents the type you want to convert from.</param>
        /// <returns>Returns <c>True</c>, if this converter can perform the conversion; otherwise returns <c>False</c>.</returns>
        bool CanConvertFrom(ITypeDescriptorContext ctx, Type type);

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="ctx"><see cref="ITypeDescriptorContext"/> instance that provides a format context.</param>
        /// <param name="culture"><see cref="CultureInfo"/> instance to use as the current culture.</param>
        /// <param name="value">Object to convert.</param>
        /// <returns>Returns the object that represents the converted value.</returns>
        object ConvertFrom(ITypeDescriptorContext ctx, CultureInfo culture, object value);
    }
}