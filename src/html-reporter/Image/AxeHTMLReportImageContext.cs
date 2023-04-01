// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace AxeCore.HTMLReporter.Image
{
    /// <summary>
    /// The information related to include and display images in the HTML Report.
    /// </summary>
    public sealed class AxeHTMLReportImageContext
    {
        /// <summary>
        /// Source Image of the page.
        /// </summary>
        public ReportImage SourceImage { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sourceImage">Source Image of the page.</param>
        public AxeHTMLReportImageContext(ReportImage sourceImage)
        {
            SourceImage = sourceImage;
        }
    }
}
