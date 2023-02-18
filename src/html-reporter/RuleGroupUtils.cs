// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using AxeCore.HTMLReporter.Content;
using AxeCore.HTMLReporter.Models;
using Deque.AxeCore.Commons;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AxeCore.HTMLReporter
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

            if (rulesToInclude.HasFlag(AxeReportRuleTypes.Violations) || rulesToInclude.HasFlag(AxeReportRuleTypes.All))
            {
                yield return CreateRuleGroup(ReportContants.ViolationsKey, violations, language);
            }
            if (rulesToInclude.HasFlag(AxeReportRuleTypes.Passes) || rulesToInclude.HasFlag(AxeReportRuleTypes.All))
            {
                yield return CreateRuleGroup(ReportContants.PassesKey, passes, language);
            }
            if (rulesToInclude.HasFlag(AxeReportRuleTypes.Inapplicable) || rulesToInclude.HasFlag(AxeReportRuleTypes.All))
            {
                yield return CreateRuleGroup(ReportContants.InapplicableKey, inapplicable, language);
            }
            if (rulesToInclude.HasFlag(AxeReportRuleTypes.Incomplete) || rulesToInclude.HasFlag(AxeReportRuleTypes.All))
            {
                yield return CreateRuleGroup(ReportContants.IncompleteKey, incomplete, language);
            }

            yield break;
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
    }
}
