// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace AxeCore.HTMLReporter
{
    /// <inheritdoc />
    public sealed class AxeHTMLReporter : IAxeHTMLReporter
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static AxeHTMLReporter Instance { get; } = new AxeHTMLReporter();

        internal AxeHTMLReporter()
        {
        }

        /// <inheritdoc />
        public AxeHTMLReport CreateReport(object results, AxeHTMLReportOptions options = null)
        {
            // TODO IsaacWalker - Implement Report Generation
            return new AxeHTMLReport("<a> Hello World </a>");
        }
    }
}
