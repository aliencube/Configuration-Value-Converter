using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;

using Aliencube.ConfigurationValueConverter.Interfaces;

namespace Aliencube.ConfigurationValueConverter
{
    /// <summary>
    /// This represents a converter entity to convert string to flagged enum value.
    /// </summary>
    /// <typeparam name="TEnum">Enum type.</typeparam>
    /// <remarks>Refer to the page http://msdn.microsoft.com/en-us/library/System.Configuration.ConfigurationConverterBase(v=vs.110).aspx .</remarks>
    public class PipeDelimitedFlaggedEnumConverter<TEnum> : ConfigurationConverterBase, IPipeDelimitedFlaggedEnumConverter where TEnum : struct
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
            var result = type == typeof(TEnum);
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

            var segments = ((string)value).Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            var converted = 0;
            foreach (var segment in segments)
            {
                TEnum result;
                if (!Enum.TryParse((string)segment, true, out result))
                {
                    throw new InvalidOperationException($"Invalid enum value - {segment}");
                }

                converted += Convert.ToInt32(result);
            }

            return (TEnum)Enum.ToObject(typeof(TEnum), converted);
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