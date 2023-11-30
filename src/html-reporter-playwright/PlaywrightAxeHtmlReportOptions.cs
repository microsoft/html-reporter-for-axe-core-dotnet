// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Microsoft.HtmlReporterForAxeCore.Playwright
{
    /// <inheritdoc />
    public sealed class PlaywrightAxeHTMLReportOptions : AxeHTMLReportOptions
    {
        /// <summary>
        /// Report Filename
        /// </summary>
        public string ReportFilename { get; set; } = null;
    }
}
