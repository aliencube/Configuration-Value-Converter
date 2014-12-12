# Configuration Value Converter #

**Configuration Value Converter (CVC)** provides an enum value converter for configuration sectionis from `App.config` or `Web.config`.


## Package Status ##

* **Case Insensitive Enum Value Converter** [![](https://img.shields.io/nuget/v/Aliencube.CaseInsensitiveEnumConverter.svg)](https://www.nuget.org/packages/Aliencube.CaseInsensitiveEnumConverter/) [![](https://img.shields.io/nuget/dt/Aliencube.CaseInsensitiveEnumConverter.svg)](https://www.nuget.org/packages/Aliencube.CaseInsensitiveEnumConverter/)
* **Comma Delimited List Value Converter** [![](https://img.shields.io/nuget/v/Aliencube.CommaDelimitedListConverter.svg)](https://www.nuget.org/packages/Aliencube.CommaDelimitedListConverter/) [![](https://img.shields.io/nuget/dt/Aliencube.CommaDelimitedListConverter.svg)](https://www.nuget.org/packages/Aliencube.CommaDelimitedListConverter/)


## Getting Started ##

The following `App.config` sample can be found at [https://github.com/aliencube/Configuration-Value-Converter/blob/master/SourceCodes/01_Configs/ConfigurationValueConverter.Configs/App.config](https://github.com/aliencube/Configuration-Value-Converter/blob/master/SourceCodes/01_Configs/ConfigurationValueConverter.Configs/App.config)

```xml
<configuration>
  <configSections>
    <section name="converterSettings" type="Aliencube.ConfigurationValueConverter.Configs.ConverterSettings, Aliencube.ConfigurationValueConverter.Configs" requirePermission="false" />
  </configSections>

  <converterSettings>
    <product status="active" productIds="1,2,3" />
  </converterSettings>
</configuration>
```

As you can see above, the `product` element has an attribute of `status`. This attribute can have either `active` or `inactive` as an enum value. In order for the attribute to be convertible without case-sensitivity, the configuration section element can be defined:

```csharp
public class ProductElement : ConfigurationElement
{
  [ConfigurationProperty("status", IsRequired = true)]
  [TypeConverter(typeof(CaseInsensitiveEnumConverter<ProductStatus>))]
  public ProductStatus Status
  {
    get { return (ProductStatus)this["status"]; }
    set { this["status"] = value; }
  }

  [ConfigurationProperty("productIds", IsRequired = true)]
  [TypeConverter(typeof(CommaDelimitedListConverter<int>))]
  public List<int> ProductIds
  {
    get { return (List<int>)this["productIds"]; }
    set { this["productIds"] = value; }
  }
}
```

* Once the `TypeConverter` attribute class is declared, with `CaseInsensitiveEnumConverter<TEnum>` type, any value such as `ACTIVE`, `Active`, or `active` can be set.
* Once the `TypeConverter` attribute class is declared, with `CommaDelimitedListConverter<T>` type, any value such as `1,2,3` can be converted to a `List<int>` object.


## Contribution ##

Your contribution is always welcome! All your work should be done in the`dev` branch. Once you finish your work, please send us a pull request on `dev` for review. Make sure that all your changes **MUST** be covered with test codes; otherwise yours won't get accepted.


## License ##

**CVC** is released under [MIT License](http://opensource.org/licenses/MIT).

> The MIT License (MIT)
> 
> Copyright (c) 2014 [aliencube.org](http://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
> furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.