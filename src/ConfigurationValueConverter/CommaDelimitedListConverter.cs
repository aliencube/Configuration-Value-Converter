using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;

using Aliencube.ConfigurationValueConverter.Interfaces;

namespace Aliencube.ConfigurationValueConverter
{
    /// <summary>
    /// This represents a converter entity to convert string to enum value.
    /// </summary>
    /// <typeparam name="T">Type to be listed.</typeparam>
    /// <remarks>Refer to the page http://msdn.microsoft.com/en-us/library/System.Configuration.ConfigurationConverterBase(v=vs.110).aspx .</remarks>
    public class CommaDelimitedListConverter<T> : ConfigurationConverterBase, ICommaDelimitedListConverter
    {
        private bool _disposed;

        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="ctx"><see cref="ITypeDescriptorContext"/> instance that provides a format context.</param>
        /// <param name="type"><see cref="Type"/> object that represents the type you want to convert from.</param>
        /// <returns>Returns <c>True</c>, if this converter can perform the conversion; otherwise returns <c>False</c>.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext ctx, Type type)
        {
            var result = type == typeof(T);
            return result;
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context"><see cref="ITypeDescriptorContext"/> instance that provides a format context.</param>
        /// <param name="culture"><see cref="CultureInfo"/> instance to use as the current culture.</param>
        /// <param name="value">Object to convert.</param>
        /// <returns>Returns the object that represents the converted value.</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var segments = ((string)value).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var result = segments.Select(p => (T)ChangeType(typeof(T), p.Trim())).ToList();
            return result;
        }

        /// <summary>
        /// Changes type of the given value.
        /// </summary>
        /// <param name="type">Type to convert.</param>
        /// <param name="value">Value to convert.</param>
        /// <returns>Returns the value whose type is changed.</returns>
        private static object ChangeType(Type type, string value)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            object result;
            if (type.IsEnum)
            {
                result = Enum.Parse(type, value, true);
                return result;
            }

            result = Convert.ChangeType(value, type);
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