// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.


using AxeCore.HTMLReporter.Models;
using Deque.AxeCore.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AxeCore.HTMLReporter
{
    internal static class MapperHelper
    {
        internal static IDictionary<string, IList<RuleInfoModel>> MapAxeResultsToResultsGroup(AxeResult results)
        {
            return new Dictionary<string, IList<RuleInfoModel>>()
            {
                { ReportContants.ViolationsKey, MapAxeResultToRuleInfo(results.Violations ?? Array.Empty<AxeResultItem>()) },
                { ReportContants.PassesKey, MapAxeResultToRuleInfo(results.Passes ?? Array.Empty<AxeResultItem>()) },
                { ReportContants.IncompleteKey, MapAxeResultToRuleInfo(results.Incomplete ?? Array.Empty<AxeResultItem>()) },
                { ReportContants.Inapplicable, MapAxeResultToRuleInfo(results.Inapplicable ?? Array.Empty < AxeResultItem >()) },
            };
        }

        private static List<RuleInfoModel> MapAxeResultToRuleInfo(AxeResultItem[] resultItems)
        {
            return resultItems.Select(axeResultItem =>
            {
                string id = WebUtility.HtmlEncode(axeResultItem.Id);
                string displayName = WebUtility.HtmlEncode(axeResultItem.Id?.Replace('-', ' '));
                string description = WebUtility.HtmlEncode(axeResultItem.Description);
                string impact = WebUtility.HtmlEncode(axeResultItem.Impact);
                Uri helpUrl = new Uri(axeResultItem.HelpUrl);
                IList<string> tags = axeResultItem.Tags ?? Array.Empty<string>();

                IList<RuleNodeInfoModel> nodes = axeResultItem.Nodes?.Select(node =>
                {
                    string html = WebUtility.HtmlEncode(node.Html ?? string.Empty);
                    string selector = WebUtility.HtmlEncode(node.Target?.ToString());

                    return new RuleNodeInfoModel(html, selector);
                }).ToList() ?? Array.Empty<RuleNodeInfoModel>().ToList();

                return new RuleInfoModel(id, displayName, description, impact, helpUrl, tags, nodes);
            }).ToList();
        }
    }
}
