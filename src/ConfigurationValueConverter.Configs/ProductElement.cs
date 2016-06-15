using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace Aliencube.ConfigurationValueConverter.Configs
{
    /// <summary>
    /// This represents the product element entity.
    /// </summary>
    public class ProductElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the <see cref="ProductStatus"/> value expected.
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

        /// <summary>
        /// Gets or sets the <see cref="ProductTypes"/> value expected.
        /// </summary>
        [ConfigurationProperty("types", IsRequired = true)]
        [TypeConverter(typeof(PipeDelimitedFlaggedEnumConverter<ProductTypes>))]
        public ProductTypes Types
        {
            get { return (ProductTypes)this["types"]; }
            set { this["types"] = value; }
        }
    }
}