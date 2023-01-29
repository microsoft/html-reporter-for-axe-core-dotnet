// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using AxeCore.HTMLReporter;
using AxeCore.HTMLReporter.DevServer;
using Deque.AxeCore.Commons;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

IAxeHTMLReporter reporter = AxeHTMLReporter.Instance;

app.MapGet("/", (context) =>
{
    AxeResult mockResult = MockDataFactory.CreateMockResultData();

    AxeHTMLReport report = reporter.CreateReport(mockResult);
    return context.Response.WriteAsync(report.ToString());
});

app.Run();
