using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using Aliencube.ConfigurationConverters.Interfaces;

namespace Aliencube.ConfigurationConverters
{
    /// <summary>
    /// This represents a converter entity to convert string to enum value.
    /// </summary>
    /// <typeparam name="T">Type to be listed.</typeparam>
    public class CommaDelimitedListConverter<T> : ConfigurationConverterBase, ICommaDelimitedListConverter
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
            var result = type == typeof(T);
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

            var segments = ((string)value).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var result = segments.Select(p => (T) ChangeType(typeof (T), p.Trim())).ToList();
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
                throw new ArgumentNullException("type");
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