// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Microsoft.HtmlReporterForAxeCore.Selenium
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
