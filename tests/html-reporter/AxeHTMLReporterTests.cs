// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using NUnit.Framework;

namespace AxeCore.HTMLReporter.Tests
{
    [TestFixture]
    public sealed class AxeHTMLReporterTests
    {
        [Test]
        public void Test()
        {
            AxeHTMLReporter reporter = GetInstance();

            AxeHTMLReport report = reporter.CreateReport(TestData.CreateDefaultResult());

            Assert.IsNotNull(report);
            Assert.IsNotEmpty(report.ToString());
        }

        private AxeHTMLReporter GetInstance()
        {
            return AxeHTMLReporter.Instance;
        }
    }
}
