# Case Insensitive Enum Converter [![](https://img.shields.io/nuget/v/Aliencube.CaseInsensitiveEnumConverter.svg)](https://www.nuget.org/packages/Aliencube.CaseInsensitiveEnumConverter/) [![](https://img.shields.io/nuget/dt/Aliencube.CaseInsensitiveEnumConverter.svg)](https://www.nuget.org/packages/Aliencube.CaseInsensitiveEnumConverter/) #

**Case Insensitive Enum Converter (CIEC)** provides an enum value converter for configuration sectionis from `App.config` or `Web.config`.


## Getting Started ##

The following `App.config` sample can be found at [https://github.com/aliencube/Case-Insensitive-Enum-Converter/blob/master/SourceCodes/01_Configs/EnumConverter.Configs/App.config](https://github.com/aliencube/Case-Insensitive-Enum-Converter/blob/master/SourceCodes/01_Configs/EnumConverter.Configs/App.config)

```xml
<configuration>
  <configSections>
    <section name="enumConverterSettings" type="Aliencube.EnumConverter.Configs.EnumConverterSettings, Aliencube.EnumConverter.Configs" requirePermission="false" />
  </configSections>

  <enumConverterSettings>
    <product status="active" />
  </enumConverterSettings>
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
}
```

Once the `TypeConverter` attribute class is declared, with `CaseInsensitiveEnumConverter<TEnum>` type, any value such as `ACTIVE`, `Active`, or `active` can be set.


## Contribution ##

Your contribution is always welcome! All your work should be done in the`dev` branch. Once you finish your work, please send us a pull request on `dev` for review. Make sure that all your changes **MUST** be covered with test codes; otherwise yours won't get accepted.


## License ##

**CIEC** is released under [MIT License](http://opensource.org/licenses/MIT).

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