// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.HtmlReporterForAxeCore.Image;
using NUnit.Framework;

namespace Microsoft.HtmlReporterForAxeCore.Tests
{
    [TestFixture]
    public sealed class AxeHTMLReporterTests
    {
        [Test]
        public void CreateReport_ReportShouldNotBeNullOrEmpty()
        {
            AxeHTMLReporter reporter = AxeHTMLReporter.Instance;

            AxeHTMLReport report = reporter.CreateReport(TestData.CreateDefaultResult());

            Assert.IsNotNull(report);
            Assert.IsNotEmpty(report.ToString());
        }

        [Test]
        public void CreateReport_WithImageContext_ReportShouldNotBeNullOrEmpty()
        {
            AxeHTMLReporter reporter = AxeHTMLReporter.Instance;

            ReportImage reportImage = new ReportImage(new byte[] { 1, 1, 1, 1 }, ImageFormat.JPeg);

            AxeHTMLReportImageContext imageContext = new AxeHTMLReportImageContext(reportImage);

            AxeHTMLReport report = reporter.CreateReport(TestData.CreateDefaultResult(), null, imageContext);

            Assert.IsNotNull(report);
            Assert.IsNotEmpty(report.ToString());
        }
    }
}
