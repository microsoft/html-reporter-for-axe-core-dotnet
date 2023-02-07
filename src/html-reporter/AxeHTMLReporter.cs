// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using AxeCore.HTMLReporter.Content;
using AxeCore.HTMLReporter.Models;
using AxeCore.HTMLReporter.Templates;
using Deque.AxeCore.Commons;
using HandlebarsDotNet;
using System;
using System.Globalization;
using System.Linq;
using System.Net;

namespace AxeCore.HTMLReporter
{
    /// <inheritdoc />
    public sealed class AxeHTMLReporter : IAxeHTMLReporter
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static AxeHTMLReporter Instance { get; }

        static AxeHTMLReporter()
        {
            Instance = new AxeHTMLReporter();
        }

        internal AxeHTMLReporter()
        {
        }

        /// <inheritdoc />
        public AxeHTMLReport CreateReport(AxeResult results, AxeHTMLReportOptions options = null)
        {
            string documentBody = HtmlTemplates.DocumentBody;

            IHandlebars handlebars = Handlebars.Create();

            handlebars.RegisterTemplate("RuleGroup", HtmlTemplates.RuleGroup);
            handlebars.RegisterTemplate("Rule", HtmlTemplates.Rule);
            handlebars.RegisterTemplate("RuleNode", HtmlTemplates.RuleNode);

            var template = handlebars.Compile(documentBody);

            ReportViewModel model = CreateReportModel(results);

            var result = template(model);

            return new AxeHTMLReport(result);
        }

        private ReportViewModel CreateReportModel(AxeResult results)
        {
            CultureInfo language = CultureInfo.CurrentCulture;

            string formattedTimestamp = results.Timestamp.HasValue
                ? results.Timestamp.Value.DateTime.ToString("U", language.DateTimeFormat)
                : null;

            return new ReportViewModel()
            {
                LanguageCode = language.TwoLetterISOLanguageName,
                LanguageDirection = language.TextInfo.IsRightToLeft ? "rtl" : "ltr",
                Title = Strings.Title,
                TestUrlRowName = Strings.TestUrlRowName,
                TestUrl = results.Url,
                TimestampRowName = Strings.TimestampRowName,
                Timestamp = formattedTimestamp,
                ViolationsRowName = Strings.ViolationsRowName,
                ViolationsKey = ReportContants.ViolationsKey,
                ViolationsCount = results.Violations.Length,
                PassesRowName = Strings.PassesRowName,
                PassesKey = ReportContants.PassesKey,
                PassesCount = results.Passes.Length,
                IncompleteRowName = Strings.IncompleteRowName,
                IncompleteKey = ReportContants.IncompleteKey,
                IncompleteCount = results.Incomplete.Length,
                InapplicableRowName = Strings.InapplicableRowName,
                InapplicableKey = ReportContants.InapplicableKey,
                InapplicableCount = results.Inapplicable.Length,
                RuleGroups = new RuleGroupModel[]
                {
                    CreateRuleGroup(ReportContants.ViolationsKey, results.Violations),
                    CreateRuleGroup(ReportContants.PassesKey, results.Passes),
                    CreateRuleGroup(ReportContants.InapplicableKey, results.Inapplicable),
                    CreateRuleGroup(ReportContants.IncompleteKey, results.Incomplete),
                }
            };
        }

        private RuleGroupModel CreateRuleGroup(string ruleGroupId, AxeResultItem[] itemResults)
        {
            return new RuleGroupModel()
            {
                RuleGroupId = ruleGroupId,
                Rules = itemResults.Select(ruleResult => new RuleModel()
                {
                    RuleId = ruleResult.Id,
                    RuleTitle = WebUtility.HtmlEncode(string.Format(Strings.RuleHeaderTemplate, ruleResult.Id.Replace('-', ' '), ruleResult.Help)),
                    ImpactRowName = Strings.ImpactRowName,
                    Impact = ruleResult.Impact,
                    HelpUrlRowName = Strings.HelpUrlRowName,
                    HelpUrl = ruleResult.HelpUrl,
                    TagsRowName = Strings.TagsRowName,
                    Tags = string.Join(", ", ruleResult.Tags),
                    RuleNodes = ruleResult.Nodes?.Select(node => new RuleNodeModel()
                    {
                        HTMLLabel = Strings.HTMLLabel,
                        HTML = WebUtility.HtmlEncode(node.Html),
                        SelectorLabel = Strings.SelectorsLabel,
                        Selector = WebUtility.HtmlEncode(node.Target.ToString()),
                    }).ToArray() ?? Array.Empty<RuleNodeModel>()
                }).ToArray(),
            };
        }
    }
}
