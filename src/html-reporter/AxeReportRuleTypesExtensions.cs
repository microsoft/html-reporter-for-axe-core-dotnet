// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Microsoft.HtmlReporterForAxeCore
{
    /// <summary>
    /// Axe Report Rule Types Extensions
    /// </summary>
    internal static class AxeReportRuleTypesExtensions
    {
        /// <summary>
        /// Are Violations Included
        /// </summary>
        public static bool IncludesViolations(this AxeReportRuleTypes ruleTypes) => ruleTypes.HasFlag(AxeReportRuleTypes.Violations)
                || ruleTypes.HasFlag(AxeReportRuleTypes.All);

        /// <summary>
        /// Are Passes Included
        /// </summary>
        public static bool IncludesPasses(this AxeReportRuleTypes ruleTypes) => ruleTypes.HasFlag(AxeReportRuleTypes.Passes)
                || ruleTypes.HasFlag(AxeReportRuleTypes.All);

        /// <summary>
        /// Are Incomplete Rules Incuded
        /// </summary>
        public static bool IncludesIncomplete(this AxeReportRuleTypes ruleTypes) => ruleTypes.HasFlag(AxeReportRuleTypes.Incomplete)
                || ruleTypes.HasFlag(AxeReportRuleTypes.All);

        /// <summary>
        /// Are Applicable Rules Included
        /// </summary>
        public static bool IncludesInapplicable(this AxeReportRuleTypes ruleTypes) => ruleTypes.HasFlag(AxeReportRuleTypes.Inapplicable)
                || ruleTypes.HasFlag(AxeReportRuleTypes.All);
    }
}
