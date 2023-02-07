// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using NUnit.Framework;

namespace AxeCore.HTMLReporter.Tests
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
    }
}
