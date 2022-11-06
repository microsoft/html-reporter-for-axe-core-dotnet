// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

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
        /// <param name="results">The axe-core results. TODO IsaacWalker - integrate with https://github.com/dequelabs/axe-core-nuget/blob/develop/packages/commons/src/AxeResult.cs</param>
        /// <param name="options">HTML Report options.</param>
        /// <returns>The HTML report object.</returns>
        AxeHTMLReport CreateReport(object results, AxeHTMLReportOptions options = null);
    }
}
