// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using NUnit.Framework;

namespace AxeCore.HTMLReporter.Tests
{
    [TestFixture]
    public class AxeHTMLReportTests
    {
        [Test]
        public void ToString_ShouldReturnMarkup()
        {
            const string markup = "<h1>hello</h2>";

            AxeHTMLReport report = new AxeHTMLReport(markup);
            string actualMarkup = report.ToString();

            Assert.AreEqual(markup, actualMarkup);
        }
    }
}
