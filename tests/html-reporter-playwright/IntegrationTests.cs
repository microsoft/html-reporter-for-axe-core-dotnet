// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using Deque.AxeCore.Commons;
using System.Collections.Generic;
using Microsoft.Playwright;

namespace Microsoft.HtmlReporterForAxeCore.Playwright.Tests
{
    [TestFixture]
    [Category("Integration")]
    public sealed class IntegrationTests : PageTest
    {
        [Test]
        public async Task RunAxe_DefaultOverride_ShouldCreateHTMLReport()
        {
            string reportFilename = GetTestFileName();

            await NavigateToTestPage();

            PlaywrightAxeHTMLReportOptions htmlReportOptions = new()
            {
                ReportFilename = reportFilename,
            };

            await Page.RunAxe(null, htmlReportOptions: htmlReportOptions);

            FileAssert.Exists(reportFilename);
        }

        [Test]
        public async Task RunAxe_WithContextOverride_ShouldCreateHTMLReport()
        {
            string reportFilename = GetTestFileName();

            await NavigateToTestPage();

            PlaywrightAxeHTMLReportOptions htmlReportOptions = new()
            {
                ReportFilename = reportFilename,
            };

            AxeRunContext context = new()
            {
                Exclude = new List<AxeSelector>
                {
                    new AxeSelector("a")
                }
            };

            await Page.RunAxe(context, null, null, htmlReportOptions: htmlReportOptions);

            FileAssert.Exists(reportFilename);
        }

        [Test]
        public async Task RunAxe_LocatorOverride_ShouldCreateHTMLReport()
        {
            string reportFilename = GetTestFileName();

            await NavigateToTestPage();

            PlaywrightAxeHTMLReportOptions htmlReportOptions = new()
            {
                ReportFilename = reportFilename,
            };

            ILocator formLocator = Page.Locator("form");
            await formLocator.RunAxe(null, htmlReportOptions);

            FileAssert.Exists(reportFilename);
        }

        /// <summary>
        /// Rather than running a development server for the tests we will use a file protocol and local test files.
        /// </summary>
        private async Task NavigateToTestPage(string file = "default-test-page.html")
        {
            string fullFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", file);

            if (!File.Exists(fullFilePath))
            {
                throw new FileNotFoundException($"File not found at {fullFilePath}");
            }

            Uri uri = new($"file://{fullFilePath}");

            await Page.GotoAsync(uri.ToString());
        }

        private static string GetTestFileName()
        {
            return string.Join("-", TestContext.CurrentContext.Random.NextGuid(), TestContext.CurrentContext.Test.MethodName, "Report.html");
        }
    }
}
