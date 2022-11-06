// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace AxeCore.HTMLReporter
{
    /// <summary>
    /// Axe HTML Report
    /// </summary>
    public sealed class AxeHTMLReport
    {
        private readonly string m_htmlContent;

        internal AxeHTMLReport(string htmlContent)
        {
            m_htmlContent = htmlContent;
        }

        /// <inheritdoc />
        public override string ToString() => m_htmlContent;

        /// <summary>
        /// Writes the HTML report to a file.
        /// </summary>
        /// <param name="filename">The outputted filename. Defaults to 'index.html'.</param>
        /// <returns>This instance.</returns>
        public AxeHTMLReport WriteToFile(string filename = null)
        {
            // TODO IsaacWalker - Write to file
            return this;
        }
    }
}
