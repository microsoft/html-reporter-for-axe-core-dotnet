// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Deque.AxeCore.Commons;
using Deque.AxeCore.Playwright;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace AxeCore.HTMLReporter.Playwright
{
    /// <summary>
    /// Page Extensions which add HTML Report Options
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Runs Axe against the page in its current state.
        /// </summary>
        /// <param name="page">The Playwright Page object</param>
        /// <param name="options">Options for running Axe.</param>
        /// <param name="htmlReportOptions">HTML report options.</param>
        /// <returns>The AxeResult</returns>
        public static async Task<AxeResult> RunAxe(
            this IPage page,
            AxeRunOptions options,
            PlaywrightAxeHtmlReportOptions htmlReportOptions)
            => await RunAxeInner(page, null, options, null, htmlReportOptions);

        /// <summary>
        /// Runs Axe against the page in its current state.
        /// </summary>
        /// <param name="page">The Playwright Page object</param>
        /// <param name="context">Context to specify which element to run axe on.</param>
        /// <param name="options">Options for running Axe.</param>
        /// <param name="htmlReportOptions">HTML report options.</param>
        /// <returns>The AxeResult</returns>
        public static async Task<AxeResult> RunAxe(
            this IPage page,
            AxeRunContext context,
            AxeRunOptions options,
            string axeSource,
            PlaywrightAxeHtmlReportOptions htmlReportOptions)
            => await RunAxeInner(page, context, options, axeSource, htmlReportOptions);

        public static async Task<AxeResult> RunAxe(
            this ILocator locator,
            AxeRunOptions options,
            PlaywrightAxeHtmlReportOptions htmlReportOptions)
        {
            AxeResult results = await locator.RunAxe(options);
            CreateReportAndWriteFile(results, htmlReportOptions);

            return results;
        }

        private static async Task<AxeResult> RunAxeInner(
            IPage page,
            AxeRunContext context,
            AxeRunOptions runOptions,
            string axeSource,
            PlaywrightAxeHtmlReportOptions htmlReportOptions)
        {
            AxeResult results = await page.RunAxe(context, runOptions, axeSource);
            CreateReportAndWriteFile(results, htmlReportOptions);

            return results;
        }

        private static void CreateReportAndWriteFile(AxeResult results, PlaywrightAxeHtmlReportOptions htmlReportOptions)
        {
            IAxeHTMLReporter reporter = AxeHTMLReporter.Instance;
            AxeHTMLReport report = reporter.CreateReport(results, htmlReportOptions);

            report.WriteToFile(htmlReportOptions.ReportFilename);
        }
    }
}
