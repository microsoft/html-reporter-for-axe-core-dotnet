// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AxeCore.HTMLReporter.Image
{
    /// <summary>
    /// Common Utilities for Images in the report
    /// </summary>
    internal static class ImageUtils
    {
        private static readonly IReadOnlyDictionary<ImageFormat, string> s_formatToMediaTypesMap = new Dictionary<ImageFormat, string>()
        {
            [ImageFormat.JPeg] = "image/jpeg",
            [ImageFormat.Png] = "image/png"
        };

        /// <summary>
        /// Creates a valid data uri from an image buffer.
        /// </summary>
        public static Uri CreateDataUri(byte[] imageBuffer, ImageFormat format)
        {
            string base64Data = Convert.ToBase64String(imageBuffer);
            string mediaType = s_formatToMediaTypesMap[format];

            return new Uri($"data:{mediaType};base64,{base64Data}");
        }
    }
}
