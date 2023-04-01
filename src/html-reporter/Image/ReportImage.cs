// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace AxeCore.HTMLReporter.Image
{
    /// <summary>
    /// Image which can be embedded in the HTML Report
    /// </summary>
    public sealed class ReportImage
    {
        /// <summary>
        /// Image Buffer Data
        /// </summary>
        public byte[] Bytes { get; }

        /// <summary>
        /// Format
        /// </summary>
        public ImageFormat Format { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bytes">Image Buffer Data</param>
        /// <param name="format">Format</param>
        public ReportImage(byte[] bytes, ImageFormat format)
        {
            Bytes = bytes;
            Format = format;
        }
    }
}
