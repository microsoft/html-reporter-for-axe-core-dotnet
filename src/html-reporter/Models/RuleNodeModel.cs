// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace AxeCore.HTMLReporter.Models
{
    /// <summary>
    /// Rule Node Model
    /// </summary>
    internal sealed class RuleNodeModel
    {
        /// <summary>
        /// HTML Label
        /// </summary>
        public string HTMLLabel { get; set; }

        /// <summary>
        /// HTML Markup
        /// </summary>
        public string HTML { get; set; }

        /// <summary>
        /// Selector Label
        /// </summary>
        public string SelectorLabel { get; set; }

        /// <summary>
        /// Selector
        /// </summary>
        public string Selector { get; set; }
    }
}
