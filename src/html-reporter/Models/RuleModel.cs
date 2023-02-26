// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace AxeCore.HTMLReporter.Models
{
    /// <summary>
    /// Rule Model
    /// </summary>
    internal sealed class RuleModel
    {
        /// <summary>
        /// Rule Id
        /// </summary>
        public string RuleId { get; set; }

        /// <summary>
        /// Rule Title
        /// </summary>
        public string RuleTitle { get; set; }

        /// <summary>
        /// Rule Group Id
        /// </summary>
        public string RuleGroupId { get; set; }

        /// <summary>
        /// Rule Outcome Row Name
        /// </summary>
        public string RuleOutcomeRowName { get; set; }

        /// <summary>
        /// Rule Outcome
        /// </summary>
        public string RuleOutcome { get; set; }

        /// <summary>
        /// Impact Row Name
        /// </summary>
        public string ImpactRowName { get; set; }

        /// <summary>
        /// Impact
        /// </summary>
        public string Impact { get; set; }

        /// <summary>
        /// Help Url Row Name
        /// </summary>
        public string HelpUrlRowName { get; set; }

        /// <summary>
        /// Help Url
        /// </summary>
        public string HelpUrl { get; set; }

        /// <summary>
        /// Tags Row Name
        /// </summary>
        public string TagsRowName { get; set; }

        /// <summary>
        /// Tags
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Rule Nodes
        /// </summary>
        public RuleNodeModel[] RuleNodes { get; set; }
    }
}
