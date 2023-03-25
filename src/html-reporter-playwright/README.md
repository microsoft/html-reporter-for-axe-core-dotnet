# AxeCore.HTMLReporter.Playwright

HTML report generation integration for [Deque.AxeCore.Playwright](https://github.com/dequelabs/axe-core-nuget/blob/develop/packages/playwright).

## Getting Started

Install via NuGet:

```powershell
PM> Install-Package AxeCore.HTMLReporter.Playwight
# or, use the Visual Studio "Manage NuGet Packages" UI
```

Import the namespace:

```csharp
using AxeCore.HTMLReporter.Playwight;
```

This adds a `RunAxe()` overload which includes HTML report options.

```csharp

PlaywrightAxeHTMLReportOptions htmlReportOptions = new()
{
    ReportFilename = "report.html",
};

await Page.RunAxe(null, htmlReportOptions: htmlReportOptions);

```

## RunAxe References

There are a number of overload extensions of RunAxe added which support the creation of a HTML Report,
plus creating it as a file.

The most common adds a htmlReportOptions alongside the regular AxeRunOptions:

```csharp

AxeRunOptions options = new AxeRunOptions();

PlaywrightAxeHTMLReportOptions htmlReportOptions = new()
{
    ReportFilename = "report.html",
};

await Page.RunAxe(options, htmlReportOptions: htmlReportOptions);

```

A report can also be created when `RunAxe` is ran on a Playwright Locator:

```csharp

ILocator locator = Page.Locator("text=Next");

AxeRunOptions options = new AxeRunOptions();

PlaywrightAxeHTMLReportOptions htmlReportOptions = new()
{
    ReportFilename = "report.html",
};

await locator.RunAxe(options, htmlReportOptions: htmlReportOptions);

```

## PlaywrightAxeHTMLReportOptions References

This class contains options for configuring the report.
It inherits from [AxeHTMLReportOptions](../html-reporter/README.md#axehtmlreportoptions-references).

### PlaywrightAxeHTMLReportOptions.ReportFilename

This is the name of the file which will be created when RunAxe is called.
It may include a relative or absolute path.

```csharp
PlaywrightAxeHTMLReportOptions htmlReportOptions = new()
{
    ReportFilename = "./reports/test1-report.html",
};
```