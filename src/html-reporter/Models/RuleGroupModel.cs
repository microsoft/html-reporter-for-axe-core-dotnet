// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Microsoft.HtmlReporterForAxeCore.Models
{
    /// <summary>
    /// View Model for Rule Group
    /// </summary>
    internal sealed class RuleGroupModel
    {
        /// <summary>
        /// Rule Group Id
        /// </summary>
        public string RuleGroupId { get; set; }

        /// <summary>
        /// Rules
        /// </summary>
        public RuleModel[] Rules { get; set; }
    }
}
