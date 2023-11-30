// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.HtmlReporterForAxeCore.Content;
using Microsoft.HtmlReporterForAxeCore.Models;
using Deque.AxeCore.Commons;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Microsoft.HtmlReporterForAxeCore
{
    /// <summary>
    /// Utilities for Rule Groups
    /// </summary>
    internal static class RuleGroupUtils
    {
        /// <summary>
        /// Maps result item arrays to create rules groups in the report.
        /// </summary>
        public static IEnumerable<RuleGroupModel> CreateRuleGroups(
            AxeResultItem[] violations,
            AxeResultItem[] passes,
            AxeResultItem[] inapplicable,
            AxeResultItem[] incomplete,
            CultureInfo language,
            AxeHTMLReportOptions options)
        {
            AxeReportRuleTypes rulesToInclude = options?.ReportRuleTypes ?? AxeReportRuleTypes.Violations;

            if (rulesToInclude.IncludesViolations())
            {
                yield return CreateRuleGroup(ReportContants.ViolationsKey, violations, language);
            }
            if (rulesToInclude.IncludesPasses())
            {
                yield return CreateRuleGroup(ReportContants.PassesKey, passes, language);
            }
            if (rulesToInclude.IncludesInapplicable())
            {
                yield return CreateRuleGroup(ReportContants.InapplicableKey, inapplicable, language);
            }
            if (rulesToInclude.IncludesIncomplete())
            {
                yield return CreateRuleGroup(ReportContants.IncompleteKey, incomplete, language);
            }

            yield break;
        }

        /// <summary>
        /// Gets the number of occurences of a rule (i.e. nodes).
        /// </summary>
        public static int GetRuleGroupNodeCount(AxeResultItem[] results)
        {
            return results?.Sum(result => result.Nodes?.Length ?? 0) ?? 0;
        }

        private static RuleGroupModel CreateRuleGroup(string ruleGroupId, AxeResultItem[] itemResults, CultureInfo locale)
        {
            return new RuleGroupModel()
            {
                RuleGroupId = ruleGroupId,
                Rules = itemResults.Select(ruleResult => new RuleModel()
                {
                    RuleId = ruleResult.Id,
                    RuleTitle = string.Format(
                        Strings.RuleHeaderTemplate,
                        locale.TextInfo.ToTitleCase(ruleResult.Id.Replace('-', ' ')), ruleResult.Help),
                    RuleGroupId = ruleGroupId,
                    RuleOutcomeRowName = Strings.RuleOutcomeRowName,
                    RuleOutcome = GetRuleOutcome(ruleGroupId),
                    ImpactRowName = Strings.ImpactRowName,
                    Impact = ruleResult.Impact,
                    HelpUrlRowName = Strings.HelpUrlRowName,
                    HelpUrl = ruleResult.HelpUrl,
                    TagsRowName = Strings.TagsRowName,
                    Tags = string.Join(", ", ruleResult.Tags ?? Array.Empty<string>()),
                    RuleNodes = ruleResult.Nodes?.Select(node => new RuleNodeModel()
                    {
                        HTMLLabel = Strings.HTMLLabel,
                        HTML = node.Html,
                        SelectorLabel = Strings.SelectorsLabel,
                        Selector = node.Target.ToString(),
                    }).ToArray() ?? Array.Empty<RuleNodeModel>()
                }).ToArray(),
            };
        }

        private static string GetRuleOutcome(string ruleGroupId)
        {
            switch (ruleGroupId)
            {
                case ReportContants.ViolationsKey:
                    return Strings.ViolationOutcome;
                case ReportContants.IncompleteKey:
                    return Strings.IncompleteOutcome;
                case ReportContants.InapplicableKey:
                    return Strings.InapplicableOutcome;
                default:
                    return Strings.PassOutcome;
            }
        }
    }
}
