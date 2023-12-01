// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.HtmlReporterForAxeCore.Playwright;
using Deque.AxeCore.Commons;
using Deque.AxeCore.Playwright;
using Microsoft.AspNetCore.Mvc;
using PlaywrightInstance = Microsoft.Playwright.Playwright;

namespace Microsoft.HtmlReporterForAxeCore.DevServer.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IAxeHTMLReporter m_reporter = AxeHTMLReporter.Instance;

        [HttpGet]
        [Route("/")]
        [Route("/{integrationType}")]
        public async Task<IActionResult> Index(IntegrationType? integrationType, Uri? testUrl, List<AxeReportRuleTypes> reportRuleTypes)
        {
            AxeHTMLReportOptions options = new()
            {
                ReportRuleTypes = reportRuleTypes.Any() ? reportRuleTypes
                    .Aggregate(reportRuleTypes.First(), (last, next) => last | next)
                    : AxeReportRuleTypes.Violations
            };

            string reportContent = string.Empty;

            if (testUrl == null)
            {
                AxeResult axeResults = MockDataFactory.CreateMockResultData();

                AxeHTMLReport report = m_reporter.CreateReport(axeResults, options);

                reportContent = report.ToString();
            }
            else
            {
                integrationType ??= IntegrationType.Playwright;

                if (integrationType == IntegrationType.Playwright)
                {
                    string filename = Path.Join(AppContext.BaseDirectory, "playwright-report.html");

                    PlaywrightAxeHTMLReportOptions playwrightAxeHTMLReportOptions = new PlaywrightAxeHTMLReportOptions()
                    {
                        ReportRuleTypes = options.ReportRuleTypes,
                        ReportFilename = filename
                    };

                    using var playwright = await PlaywrightInstance.CreateAsync();

                    await using var browser = await playwright.Chromium.LaunchAsync();
                    var page = await browser.NewPageAsync();
                    await page.GotoAsync(testUrl.ToString());

                    await page.RunAxe(null, htmlReportOptions: playwrightAxeHTMLReportOptions);

                    reportContent = ReadReportContentFromFile(filename);
                }
            }

            return Content(reportContent, System.Net.Mime.MediaTypeNames.Text.Html);
        }

        private static string ReadReportContentFromFile(string filename)
        {
            string reportContent = System.IO.File.ReadAllText(filename);
            return reportContent;
        }
    }
}
