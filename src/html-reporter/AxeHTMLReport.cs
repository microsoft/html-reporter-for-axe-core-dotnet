// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.IO;

namespace AxeCore.HTMLReporter
{
    /// <summary>
    /// Axe HTML Report
    /// </summary>
    public sealed class AxeHTMLReport
    {
        private readonly string m_htmlContent;

        private const string DefaultFilename = "index.html";

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
            string reportFilename = filename ?? DefaultFilename;

            string directory = Path.GetDirectoryName(reportFilename);

            if(!string.IsNullOrWhiteSpace(directory)) 
            {
                Directory.CreateDirectory(Path.GetDirectoryName(reportFilename));
            }

            File.WriteAllText(reportFilename, m_htmlContent);

            return this;
        }
    }
}
