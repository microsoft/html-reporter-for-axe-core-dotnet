// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using AxeCore.HTMLReporter.Image;
using Deque.AxeCore.Commons;

namespace AxeCore.HTMLReporter
{
    /// <summary>
    /// Reporter for generting HTML Report of an axe-core run result.
    /// </summary>
    public interface IAxeHTMLReporter
    {
        /// <summary>
        /// Creates a HTML Report for an axe-core run result.
        /// </summary>
        /// <param name="results">The axe-core results.</param>
        /// <param name="options">HTML Report options.</param>
        /// <param name="imageContext">Context for images being displayed in the report.</param>
        /// <returns>The HTML report object.</returns>
        AxeHTMLReport CreateReport(AxeResult results, AxeHTMLReportOptions options = null, AxeHTMLReportImageContext imageContext = null);
    }
}
