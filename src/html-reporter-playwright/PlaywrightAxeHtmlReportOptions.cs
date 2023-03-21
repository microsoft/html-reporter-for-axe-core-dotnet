// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace AxeCore.HTMLReporter.Playwright
{
    /// <inheritdoc />
    public sealed class PlaywrightAxeHtmlReportOptions : AxeHTMLReportOptions
    {
        /// <summary>
        /// Report Filename
        /// </summary>
        public string ReportFilename { get; set; } = null;
    }
}
