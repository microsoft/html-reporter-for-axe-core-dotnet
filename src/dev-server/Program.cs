// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using AxeCore.HTMLReporter;
using AxeCore.HTMLReporter.DevServer;
using Deque.AxeCore.Commons;
using Deque.AxeCore.Playwright;
using Microsoft.Playwright;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

IAxeHTMLReporter reporter = AxeHTMLReporter.Instance;

app.MapGet("/", async (context) =>
{
    AxeResult axeResults;

    if (context.Request.Query.ContainsKey("testUrl") &&
        Uri.TryCreate(context.Request.Query["testUrl"], UriKind.Absolute, out Uri? testUrl))
    {
        using var playwright = await Playwright.CreateAsync();

        await using var browser = await playwright.Chromium.LaunchAsync();
        var page = await browser.NewPageAsync();
        await page.GotoAsync(testUrl.ToString());

        axeResults = await page.RunAxe();
    }
    else
    {
        axeResults = MockDataFactory.CreateMockResultData();
    }

    AxeReportRuleTypes[] reportRuleTypes = (context.Request.Query.ContainsKey(nameof(AxeHTMLReportOptions.ReportRuleTypes))
        ? context.Request.Query[nameof(AxeHTMLReportOptions.ReportRuleTypes)]
            .Select(queryItem => Enum.Parse<AxeReportRuleTypes>(queryItem))
            .ToArray()
        : new AxeReportRuleTypes[] { AxeReportRuleTypes.Violations });

    AxeHTMLReportOptions options = new()
    {
        ReportRuleTypes = reportRuleTypes
            .Aggregate(reportRuleTypes.First(), (last, next) => last | next)
    };

    AxeHTMLReport report = reporter.CreateReport(axeResults, options);
    await context.Response.WriteAsync(report.ToString());
});

app.Run();
