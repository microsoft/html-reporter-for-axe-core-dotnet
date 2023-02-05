// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AxeCore.HTMLReporter.Models
{
    /// <summary>
    /// Represents all the information for a rule on the report.
    /// </summary>
    public sealed class RuleInfoModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Display Name
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Impact
        /// </summary>
        public string Impact { get; }

        /// <summary>
        /// Help Url
        /// </summary>
        public Uri HelpUrl { get; }

        /// <summary>
        /// Tags
        /// </summary>
        public IList<string> Tags { get; }

        /// <summary>
        /// Rule Nodes
        /// </summary>
        public IList<RuleNodeInfoModel> RuleNodes { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RuleInfoModel(
            string id,
            string displayName,
            string description,
            string impact,
            Uri helpUrl,
            IList<string> tags,
            IList<RuleNodeInfoModel> ruleNodes
            )
        {
            Id = id;
            DisplayName = displayName;
            Description = description;
            Impact = impact;
            HelpUrl = helpUrl;
            Tags = tags;
            RuleNodes = ruleNodes;
        }
    }
}
