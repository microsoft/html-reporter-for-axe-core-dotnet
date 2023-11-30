// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Deque.AxeCore.Selenium;

namespace Microsoft.HtmlReporterForAxeCore.Selenium
{
    /// <summary>
    /// Extensions which add HTML Report to AxeBuilder
    /// </summary>
    public static class AxeBuilderExtensions
    {
        /// <summary>
        /// Creates a HTML Report of the Axe results from the run.
        /// </summary>
        /// <param name="builder">The Axe Builder</param>
        /// <param name="htmlReportOptions">Options for configuring the HMTL Report</param>
        /// <returns>The builder which is passed in.</returns>
        public static AxeBuilder WithHTMLReport(this AxeBuilder builder, SeleniumAxeHtmlReportOptions htmlReportOptions = null)
        {
            // TODO IsaacWalker - hook up to selenium builder.

            return builder;
        }
    }
}
