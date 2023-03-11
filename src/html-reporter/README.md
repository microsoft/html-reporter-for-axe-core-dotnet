# AxeCore.HTMLReporter

HTML report generation for AxeResults from [axe-core-nuget](https://github.com/dequelabs/axe-core-nuget).

## Getting Started

Install via NuGet:

```powershell
PM> Install-Package AxeCore.HTMLReporter
# or, use the Visual Studio "Manage NuGet Packages" UI
```

Import the namespace:

```csharp
using AxeCore.HTMLReporter;
```

Get the HTML Reporter instance, create the report on the axeResults and write it to a file.

```csharp

AxeHTMLReporter reporter = AxeHTMLReporter.Instance;

AxeHTMLReport report = reporter.CreateReport(axeResults);

report.WriteToFile("my-html-report.html");

```

## AxeHTMLReporter References

### `AxeHTMLReport.CreateReport(AxeResult results)`

```csharp
AxeHTMLReport report = AxeHTMLReporter.Instance.CreateReport(results);
```

Creates a HTML Report instance based on the results.
This operation will not write a file.

### `AxeHTMLReport.CreateReport(AxeResult results, AxeHTMLReportOptions options)`

```csharp

AxeHTMLReportOptions options = new AxeHTMLReportOptions()
{
	ReportRuleTypes = AxeReportRuleTypes.All
};

AxeHTMLReport report = AxeHTMLReporter.Instance.CreateReport(results, options);
```

Creates a HTML Report instance based on the entered Axe results and report options.

## AxeHTMLReportOptions References

### `AxeHTMLReportOptions.ReportRuleTypes`

```csharp

// Show all rules in the report.
AxeHTMLReportOptions options = new AxeHTMLReportOptions()
{
	ReportRuleTypes = AxeReportRuleTypes.All
};

// Show violations and passes in the report.
AxeHTMLReportOptions options = new AxeHTMLReportOptions()
{
	ReportRuleTypes = AxeReportRuleTypes.Violations | AxeReportRuleTypes.Passes
};

```

Specifies what rule types to include and show in the report.

## AxeHTMLReport References

### `AxeHTMLReport.WriteToFile(string filename)`

```csharp

AxeHTMLReport report;
report.WriteToFile();

report.WriteToFile("./output/index.html");

```

Writes the HTML Report to a file. Defaults to "index.html".

### `AxeHTMLReport.ToString()`

```csharp

AxeHTMLReport report;
string reportContent = report.ToString();

```

Returns the HTML report content as a string.