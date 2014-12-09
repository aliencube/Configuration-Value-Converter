using System.ComponentModel;
using System.Configuration;

namespace Aliencube.EnumConverter.Configs
{
    /// <summary>
    /// This represents the product element entity.
    /// </summary>
    public class ProductElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the product status expected.
        /// </summary>
        [ConfigurationProperty("status", IsRequired = true)]
        [TypeConverter(typeof(CaseInsensitiveEnumConverter<ProductStatus>))]
        public ProductStatus Status
        {
            get { return (ProductStatus)this["status"]; }
            set { this["status"] = value; }
        }
    }
}