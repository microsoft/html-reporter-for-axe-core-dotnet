# Microsoft.HtmlReporterForAxeCore.Selenium

HTML reporter integration for [Deque.AxeCore.Selenium](https://github.com/dequelabs/axe-core-nuget/blob/develop/packages/selenium).

## Getting Started

Install via NuGet:

```powershell
PM> Install-Package Microsoft.HtmlReporterForAxeCore.Selenium
# or, use the Visual Studio "Manage NuGet Packages" UI
```

Import the namespace:

```csharp
using Microsoft.HtmlReporterForAxeCore.Selenium;
```

This adds a `WithHTMLReport()` extension method to the `AxeBuilder`.

```csharp

AxeBuilder builder = new AxeBuilder(m_webDriver)
    .WithHTMLReport();

AxeResult result = builder.Analyze();

```

## WithHTMLReport References

This is an extension method added to the AxeBuilder class which outputs a HTML report
file when `Analyze()` is called.

It takes an optional `SeleniumAxeHtmlReportOptions` parameter.

```csharp
SeleniumAxeHtmlReportOptions reportOptions = new();

AxeBuilder builder = new AxeBuilder(m_webDriver)
    .WithHTMLReport(reportOptions);

AxeResult result = builder.Analyze();

```

## SeleniumAxeHtmlReportOptions References

This class contains options for configuring the report.
It inherits from [AxeHTMLReportOptions](../html-reporter/README.md#axehtmlreportoptions-references).

### SeleniumAxeHtmlReportOptions.ReportFilename

This is the name of the file which will be created when Analyze is called.
It may include a relative or absolute path.

```csharp
SeleniumAxeHtmlReportOptions htmlReportOptions = new()
{
    ReportFilename = "./reports/test1-report.html",
};
```