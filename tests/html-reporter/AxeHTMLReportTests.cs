// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using NUnit.Framework;
using System.IO;

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

        [Test]
        [TestCase(null)]
        [TestCase("./testpath/myReport.html")]
        public void WriteToFile_ShouldWriteHtmlContentsToFile(string filename)
        {
            const string markup = "<h1>hello</h2>";

            AxeHTMLReport report = new AxeHTMLReport(markup);
            report.WriteToFile(filename);

            string expectedFilename = filename ?? "index.html";
            FileAssert.Exists(expectedFilename);
            Assert.AreEqual(File.ReadAllText(expectedFilename), markup);
        }
    }
}
