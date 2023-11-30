// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Deque.AxeCore.Commons;
using NUnit.Framework;
using System.Globalization;
using System.Linq;

namespace Microsoft.HtmlReporterForAxeCore.Tests
{
    [TestFixture]
    public class RuleGroupUtilsTests
    {
        [Test]
        [TestCase(
            AxeReportRuleTypes.Violations,
            new string[] { ReportContants.ViolationsKey })]
        [TestCase(
            AxeReportRuleTypes.Passes,
            new string[] { ReportContants.PassesKey })]
        [TestCase(
            AxeReportRuleTypes.Incomplete,
            new string[] { ReportContants.IncompleteKey })]
        [TestCase(
            AxeReportRuleTypes.Inapplicable,
            new string[] { ReportContants.InapplicableKey })]
        [TestCase(
            AxeReportRuleTypes.All,
            new string[] { ReportContants.ViolationsKey, ReportContants.PassesKey, ReportContants.IncompleteKey, ReportContants.InapplicableKey })]
        [TestCase(
            AxeReportRuleTypes.Inapplicable | AxeReportRuleTypes.Passes,
            new string[] { ReportContants.InapplicableKey, ReportContants.PassesKey })]
        public void CreateRuleGroups_WhenRuleReportTypeSpecified_ShouldOnlyIncludeExpected(
            AxeReportRuleTypes includeRules,
            string[] expectedRuleGroupIds
            )
        {
            var options = new AxeHTMLReportOptions()
            {
                ReportRuleTypes = includeRules
            };

            AxeResultItem[] violations = new AxeResultItem[1]
            {
                new AxeResultItem()
                {
                    Id = "violations"
                }
            };
            AxeResultItem[] passes = new AxeResultItem[1]
            {
                new AxeResultItem()
                {
                    Id = "passes"
                }
            };
            AxeResultItem[] incomplete = new AxeResultItem[1]
            {
                new AxeResultItem()
                {
                    Id = "incomplete"
                }
            };
            AxeResultItem[] inapplicable = new AxeResultItem[1]
            {
                new AxeResultItem()
                {
                    Id = "inapplicable"
                }
            };

            var ruleGroups = RuleGroupUtils.CreateRuleGroups(
                violations,
                passes,
                inapplicable,
                incomplete,
                CultureInfo.InvariantCulture,
                options);

            string[] actualRuleGroups = ruleGroups
                .Select(rg => rg.RuleGroupId)
                .ToArray();

            CollectionAssert.AreEquivalent(expectedRuleGroupIds, actualRuleGroups);
        }
    }
}
