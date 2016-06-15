﻿using System;
using System.ComponentModel;
using System.Globalization;

using Aliencube.ConfigurationValueConverter.Configs;
using Aliencube.ConfigurationValueConverter.Interfaces;

using Moq;

namespace Aliencube.ConfigurationValueConverter.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for the <see cref="PipeDelimitedFlaggedEnumConverterTest"/> class.
    /// </summary>
    public class PipeDelimitedFlaggedEnumConverterFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Initialises a new instance of the <see cref="PipeDelimitedFlaggedEnumConverterFixture"/> class.
        /// </summary>
        public PipeDelimitedFlaggedEnumConverterFixture()
        {
            this.CultureInfo = CultureInfo.InvariantCulture;

            this.TypeDescriptorContext = new Mock<ITypeDescriptorContext>();

            this.PipeDelimitedFlaggedEnumConverter = new PipeDelimitedFlaggedEnumConverter<ProductTypes>();
        }

        /// <summary>
        /// Gets the <see cref="Mock{ITypeDescriptorContext}"/> instance.
        /// </summary>
        public Mock<ITypeDescriptorContext> TypeDescriptorContext { get; }

        /// <summary>
        /// Gets the <see cref="System.Globalization.CultureInfo"/> instance.
        /// </summary>
        public CultureInfo CultureInfo { get; }

        /// <summary>
        /// Gets the <see cref="IPipeDelimitedFlaggedEnumConverter"/> instance.
        /// </summary>
        public IPipeDelimitedFlaggedEnumConverter PipeDelimitedFlaggedEnumConverter { get; }

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