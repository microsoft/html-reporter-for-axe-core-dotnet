// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace AxeCore.HTMLReporter.Models
{
    /// <summary>
    /// Represents a particular instance where a rule was calculated.
    /// </summary>
    public sealed class RuleNodeInfoModel
    {
        /// <summary>
        /// The sample markup.
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// Selector
        /// </summary>
        public string Selector { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RuleNodeInfoModel(string html, string selector) {
            Html = html;
            Selector = selector;
        }
    }
}
