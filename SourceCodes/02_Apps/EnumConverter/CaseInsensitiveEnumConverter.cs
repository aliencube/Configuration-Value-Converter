using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using Aliencube.EnumConverter.Interfaces;

namespace Aliencube.EnumConverter
{
    /// <summary>
    /// This represents a converter entity to convert string to enum value.
    /// </summary>
    /// <typeparam name="TEnum">Enum type.</typeparam>
    /// <remarks>Refer to the page http://msdn.microsoft.com/en-us/library/System.Configuration.ConfigurationConverterBase(v=vs.110).aspx .</remarks>
    public class CaseInsensitiveEnumConverter<TEnum> : ConfigurationConverterBase, ICaseInsensitiveEnumConverter where TEnum : struct
    {
        private bool _disposed;

        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="ctx"><c>ITypeDescriptorContext</c> that provides a format context.</param>
        /// <param name="type"><c>Type</c> that represents the type you want to convert from.</param>
        /// <returns>Returns <c>True</c>, if this converter can perform the conversion; otherwise returns <c>False</c>.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext ctx, Type type)
        {
            var result = type == typeof(TEnum);
            return result;
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context"><c>ITypeDescriptorContext</c> that provides a format context.</param>
        /// <param name="culture"><c>CultureInfo</c> to use as the current culture.</param>
        /// <param name="value"><c>Object</c> to convert.</param>
        /// <returns>Returns the <c>Object</c> that represents the converted value.</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            TEnum result;
            if (!Enum.TryParse((string)value, true, out result))
            {
                throw new InvalidOperationException("Invalid enum value");
            }

            return result;
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