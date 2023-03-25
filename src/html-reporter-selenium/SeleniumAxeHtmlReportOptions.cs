// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace AxeCore.HTMLReporter.Selenium
{
    /// <inheritdoc />
    public sealed class SeleniumAxeHtmlReportOptions : AxeHTMLReportOptions
    {
        /// <summary>
        /// Report Filename
        /// </summary>
        public string ReportFilename { get; set; } = null;
    }
}
