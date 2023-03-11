// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace AxeCore.HTMLReporter.Models
{
    /// <summary>
    /// View Model for Report markup
    /// </summary>
    internal sealed class ReportViewModel
    {
        /// <summary>
        /// Language Code
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// Language Direction
        /// </summary>
        public string LanguageDirection { get; set; }

        /// <summary>
        /// Document Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Test Url Row Name
        /// </summary>
        public string TestUrlRowName { get; set; }

        /// <summary>
        /// Test Url
        /// </summary>
        public string TestUrl { get; set; }

        /// <summary>
        /// Timestamp Row Name
        /// </summary>
        public string TimestampRowName { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Violations Row Name
        /// </summary>
        public string ViolationsRowName { get; set; }

        /// <summary>
        /// Violations Key
        /// </summary>
        public string ViolationsKey { get; set; }

        /// <summary>
        /// Violations Count
        /// </summary>
        public int ViolationsCount { get; set; }

        /// <summary>
        /// PassesRowName
        /// </summary>
        public string PassesRowName { get; set; }

        /// <summary>
        /// Passes Key
        /// </summary>
        public string PassesKey { get; set; }

        /// <summary>
        /// PassesCount
        /// </summary>
        public int PassesCount { get; set; }

        /// <summary>
        /// Incomplete Row Name
        /// </summary>
        public string IncompleteRowName { get; set; }

        /// <summary>
        /// Incomplete Key
        /// </summary>
        public string IncompleteKey { get; set; }

        /// <summary>
        /// Incomplete Count
        /// </summary>
        public int IncompleteCount { get; set; }

        /// <summary>
        /// Inapplicable Row Name
        /// </summary>
        public string InapplicableRowName { get; set; }

        /// <summary>
        /// Inapplicable Key
        /// </summary>
        public string InapplicableKey { get; set; }

        /// <summary>
        /// Inapplicable Count
        /// </summary>
        public int InapplicableCount { get; set; }

        /// <summary>
        /// Rule Groups
        /// </summary>
        public RuleGroupModel[] RuleGroups { get; set; }

        /// <summary>
        /// Should the count of the violated rules be shown as a link?
        /// </summary>
        public bool ShowViolationsRulesLink { get; set; }

        /// <summary>
        /// Should the count of the passed rules be shown as a link?
        /// </summary>
        public bool ShowPassesRulesLink { get; set; }

        /// <summary>
        /// Should the count of the inapplicable rules be shown as a link?
        /// </summary>
        public bool ShowInapplicableRulesLink { get; set; }

        /// <summary>
        /// Should the count of the incomplete rules be shown as a link?
        /// </summary>
        public bool ShowIncompleteRulesLink { get; set; }
    }
}
