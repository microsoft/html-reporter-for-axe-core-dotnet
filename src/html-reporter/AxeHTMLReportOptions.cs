// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace AxeCore.HTMLReporter
{
    /// <summary>
    /// Options for configuring the HTML report.
    /// </summary>
    public sealed class AxeHTMLReportOptions
    {
        /// <summary>
        /// Specifies which rule types to include in the report.
        /// </summary>
        public AxeReportRuleTypes ReportRuleTypes { get; set; } = AxeReportRuleTypes.Violations;
    }
}
