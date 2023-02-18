// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;

namespace AxeCore.HTMLReporter
{
    /// <summary>
    /// Specifies which rule types to include in the report.
    /// 
    /// May be used individually:
    /// 
    ///     var includeRules = AxeReportRuleTypes.Violations;
    ///     
    /// Or as a flag set:
    /// 
    ///     var includeRules = AxeReportRuleTypes.Violations | Violations.Passes;
    /// </summary>
    [Flags]
    public enum AxeReportRuleTypes
    {
        /// <summary>
        /// Only include rules which were violated in the report.
        /// </summary>
        Violations = 1,

        /// <summary>
        /// Only include rules which were incomplete in the report.
        /// </summary>
        Incomplete = 2,

        /// <summary>
        /// Only includes inapplicable rules in the report.
        /// </summary>
        Inapplicable = 4,

        /// <summary>
        /// Only include rules which passed in the report.
        /// </summary>
        Passes = 8,

        /// <summary>
        /// Include all rule results in the report.
        /// </summary>
        All = 16,
    }
}
