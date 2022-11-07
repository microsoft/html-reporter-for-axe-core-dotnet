// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using AxeCore.HTMLReporter;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

IAxeHTMLReporter reporter = AxeHTMLReporter.Instance;

app.MapGet("/", (context) =>
{
    AxeHTMLReport report = reporter.CreateReport("");
    return context.Response.WriteAsync(report.ToString());
});

app.Run();
