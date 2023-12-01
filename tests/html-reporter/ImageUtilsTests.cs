// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.HtmlReporterForAxeCore.Image;
using NUnit.Framework;
using System;

namespace Microsoft.HtmlReporterForAxeCore.Tests
{
    [TestFixture]
    public sealed class ImageUtilsTests
    {
        [Test]
        public void CreateDataUri_WithInputData_ShouldReturnExpectedDataUri()
        {
            byte[] inputData = new byte[] { 1, 2, 3, 4 };

            Uri expectedUri = new Uri("data:image/jpeg;base64,AQIDBA==");
            Uri actualDataUri = ImageUtils.CreateDataUri(inputData, ImageFormat.JPeg);

            Assert.AreEqual(expectedUri, actualDataUri);
        }
    }
}
