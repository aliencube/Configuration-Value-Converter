using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using Aliencube.ConfigurationConverters;

namespace Aliencube.ConfigurationValueConverter.Configs
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

        /// <summary>
        /// Gets or sets the list of product IDs.
        /// </summary>
        [ConfigurationProperty("productIds", IsRequired = true)]
        [TypeConverter(typeof(CommaDelimitedListConverter<int>))]
        public List<int> ProductIds
        {
            get { return (List<int>)this["productIds"]; }
            set { this["productIds"] = value; }
        }
    }
}