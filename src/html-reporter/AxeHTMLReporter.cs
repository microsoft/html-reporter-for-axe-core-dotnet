// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using AxeCore.HTMLReporter.Content;
using AxeCore.HTMLReporter.Models;
using AxeCore.HTMLReporter.Templates;
using Deque.AxeCore.Commons;
using HandlebarsDotNet;
using System.Globalization;
using System.Linq;

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

            ReportViewModel model = CreateReportModel(results, options);

            var result = template(model);

            return new AxeHTMLReport(result);
        }

        private ReportViewModel CreateReportModel(AxeResult results, AxeHTMLReportOptions options)
        {
            CultureInfo language = CultureInfo.CurrentCulture;

            string formattedTimestamp = results.Timestamp.HasValue
                ? results.Timestamp.Value.DateTime.ToString("U", language.DateTimeFormat)
                : null;

            RuleGroupModel[] ruleGroups = RuleGroupUtils.CreateRuleGroups(
                results.Violations,
                results.Passes,
                results.Inapplicable,
                results.Incomplete,
                language,
                options)
                .ToArray();

            int violationCount = RuleGroupUtils.GetRuleGroupNodeCount(results.Violations);
            int passesCount = RuleGroupUtils.GetRuleGroupNodeCount(results.Passes);
            int incompleteCount = RuleGroupUtils.GetRuleGroupNodeCount(results.Incomplete);
            int inapplicableCount = RuleGroupUtils.GetRuleGroupNodeCount(results.Inapplicable);

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
                ViolationsCount = violationCount,
                PassesRowName = Strings.PassesRowName,
                PassesKey = ReportContants.PassesKey,
                PassesCount = passesCount,
                IncompleteRowName = Strings.IncompleteRowName,
                IncompleteKey = ReportContants.IncompleteKey,
                IncompleteCount = incompleteCount,
                InapplicableRowName = Strings.InapplicableRowName,
                InapplicableKey = ReportContants.InapplicableKey,
                InapplicableCount = inapplicableCount,
                RuleGroups = ruleGroups
            };
        }
    }
}
