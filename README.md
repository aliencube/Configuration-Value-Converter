# Configuration Value Converter #

[![Build status](https://ci.appveyor.com/api/projects/status/g2jspuboqh7i7x5k/branch/dev?svg=true)](https://ci.appveyor.com/project/justinyoo/configuration-value-converter/branch/dev) | [![](https://img.shields.io/nuget/v/Aliencube.ConfigurationValueConverter.svg)](https://www.nuget.org/packages/Aliencube.ConfigurationValueConverter)

**Configuration Value Converter (CVC)** provides configuration value converters for configuration sections from `App.config` or `Web.config`.


## Getting Started ##

The following `App.config` sample can be found at [https://github.com/aliencube/Configuration-Value-Converter/blob/master/src/ConfigurationValueConverter.Configs/App.config](https://github.com/aliencube/Configuration-Value-Converter/blob/master/src/ConfigurationValueConverter.Configs/App.config)

```xml
<configuration>
  <configSections>
    <section name="converterSettings" 
             type="Aliencube.ConfigurationValueConverter.Configs.ConverterSettings, Aliencube.ConfigurationValueConverter.Configs" requirePermission="false" />
  </configSections>

  <converterSettings>
    <product status="active" productIds="1,2,3" types="ProductA|ProductC" />
  </converterSettings>
</configuration>
```


## `CaseInsensitiveEnumConverter` ##

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
}
```

If the `TypeConverter` attribute class is declared with `CaseInsensitiveEnumConverter<ProductStatus>` type, any value such as `ACTIVE`, `Active`, or `active` representing `ProductStatus.Active` is allowed into `App.config` or `Web.config`.


## `CommaDelimitedListConverter` ##

```csharp
public class ProductElement : ConfigurationElement
{
  [ConfigurationProperty("productIds", IsRequired = true)]
  [TypeConverter(typeof(CommaDelimitedListConverter<int>))]
  public List<int> ProductIds
  {
    get { return (List<int>)this["productIds"]; }
    set { this["productIds"] = value; }
  }
}
```

If the `TypeConverter` attribute class is declared with `CommaDelimitedListConverter<int>` type, any value such as `1,2,3` can be converted to a `List<int>` instance containing `1`, `2` and `3`.


## `PipeDelimitedFlaggedEnumConverter` ##

```csharp
public class ProductElement : ConfigurationElement
{
  [ConfigurationProperty("types", IsRequired = true)]
  [TypeConverter(typeof(PipeDelimitedFlaggedEnumConverter<ProductTypes>))]
  public ProductTypes Types
  {
      get { return (ProductTypes)this["types"]; }
      set { this["types"] = value; }
  }
}
```

If the `TypeConverter` attribute class is declared with `PipeDelimitedFlaggedEnumConverter<ProductTypes>` type, enum values delimited by a pipe sign (`|`) can be converted to a flagged enum.


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