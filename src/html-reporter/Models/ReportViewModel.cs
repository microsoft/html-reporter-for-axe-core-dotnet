// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;

namespace AxeCore.HTMLReporter.Models
{
    /// <summary>
    /// View Model for Report markup
    /// </summary>
    public sealed class ReportViewModel
    {
        /// <summary>
        /// Language of the report
        /// </summary>
        public CultureInfo Language { get; }

        /// <summary>
        /// Test URI
        /// </summary>
        public Uri TestUri { get; }

        /// <summary>
        /// Formatted Timestamp
        /// </summary>
        public string FormattedTimestamp { get; }

        /// <summary>
        /// Axe Results
        /// </summary>
        public IDictionary<string, IList<RuleInfoModel>> RuleResultGroups { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        internal ReportViewModel(CultureInfo language, Uri testUri, string formattedTimestamp, IDictionary<string, IList<RuleInfoModel>> ruleResultGroups)
        {
            Language = language;
            TestUri = testUri;
            FormattedTimestamp = formattedTimestamp;
            RuleResultGroups = ruleResultGroups;
        }
    }
}
