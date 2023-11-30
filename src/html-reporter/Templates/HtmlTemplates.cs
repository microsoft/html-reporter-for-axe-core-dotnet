// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Microsoft.HtmlReporterForAxeCore.Templates
{
    internal static class HtmlTemplates
    {
        internal static string DocumentBody = @"
            <html lang=""{{LanguageCode}}"" dir=""{{LanguageDirection}}"">
            <head>
                <title>{{Title}}</title>
                <meta charset=""utf-8"" />
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
                <style>
                    body {
                        font-family: 'Segoe ui';
                        margin: 20px;
                        display: flex;
                        flex-direction: column; 
                    }

                    h1 {
                        text-decoration-line: underline;
                    }

                    table {
                        border-collapse: collapse;
                    }

                    th, td {
                        padding: 8px;
                        text-align: left;
                        border-bottom-style: solid;
                        border-bottom-width: 2px;
                    }

                    .summaryRegion {
                        width: 40%;
                    }

                    .table-row {
                        font-weight: bold;
                    }

                    .table-entry {
                        text-align: right;
                    }

                    hr.rule-divider {
                        border: 2px solid;
                    }

                    .node-dt {
                        font-weight: bold;
                    }

                    .node-card {
                        color: black;
                        background-color: #F2F2F2;
                        padding: 20px;
                    }

                    section.rule {
                        flex-direction: column;
                    }

                    table.rule {
                        width: 40%;
                    }

                    section.violations {
                        color: #ad5c5c;
                    }

                    hr.violations {
                        border-color: #ad5c5c;
                    }

                    table.violations {
                        color: #ad5c5c;
                    }

                    section.passes {
                        color: #208720;
                    }

                    hr.passes {
                        border-color: #208720;
                    }

                    table.passes {
                        color: #208720;
                    }

                    section.incomplete {
                        color: #9b6d24;
                    }

                    hr.incomplete {
                        border-color: #9b6d24;
                    }

                    table.incomplete {
                        color: #9b6d24;
                    }

                    section.inapplicable {
                        color: #737373;
                    }

                    hr.inapplicable {
                        border-color: #737373;
                    }

                    table.inapplicable {
                        color: #737373;
                    }
                </style>
            </head>
            <body>
                <h1>{{Title}}</h1>
                <br />
                    <table class=""summaryRegion"">
                        <tr>
                            <td class=""table-row"">{{TestUrlRowName}}</td>
                            <td class=""table-entry"">{{TestUrl}}</td>
                        </tr>
                        <tr>
                            <td class=""table-row"">{{TimestampRowName}}</td>
                            <td class=""table-entry"">{{Timestamp}}</td>
                        </tr>
                        <tr>
                            <td class=""table-row"">{{ViolationsRowName}}</td>
                            <td class=""table-entry"">
                                {{#if ShowViolationsRulesLink}}
                                <a href=""#{{ViolationsKey}}"">{{ViolationsCount}}</a>
                                {{else}}
                                <span>{{ViolationsCount}}</span>
                                {{/if}}
                            </td>
                        </tr>
                        <tr>
                            <td class=""table-row"">{{PassesRowName}}</td>
                            <td class=""table-entry"">
                                {{#if ShowPassesRulesLink}}
                                <a href=""#{{PassesKey}}"">{{PassesCount}}</a>
                                {{else}}
                                <span>{{PassesCount}}</span>
                                {{/if}}
                            </td>
                        </tr>
                        <tr>
                            <td class=""table-row"">{{IncompleteRowName}}</td>
                            <td class=""table-entry"">
                                {{#if ShowIncompleteRulesLink}}
                                <a href=""#{{IncompleteKey}}"">{{IncompleteCount}}</a>
                                {{else}}
                                <span>{{IncompleteCount}}</span>
                                {{/if}}
                            </td>
                        </tr>
                        <tr>
                            <td class=""table-row"">{{InapplicableRowName}}</td>
                            <td class=""table-entry"">
                                {{#if ShowInapplicableRulesLink}}
                                <a href=""#{{InapplicableKey}}"">{{InapplicableCount}}</a>
                                {{else}}
                                <span>{{InapplicableCount}}</span>
                                {{/if}}
                            </td>
                        </tr>
                    </table>
                <br />
                {{#RuleGroups}}
                    {{> RuleGroup}}
                {{/RuleGroups}}
            </body>
        ";

        internal static string RuleGroup = @"
            <section id=""{{RuleGroupId}}"" class=""{{RuleGroupId}}"">
                {{#Rules}}
                    {{> Rule}}
                {{/Rules}}
            </section>
        ";

        internal static string Rule = @"
            <hr class=""rule-divider {{RuleGroupId}}"" />
            <section id=""rule {{RuleId}}"">
                <h2>{{RuleTitle}}</h2>
                <table class=""rule {{RuleGroupId}}"">
                    <tr>
                        <td class=""table-row"">{{RuleOutcomeRowName}}</td>
                        <td class=""table-entry"">{{RuleOutcome}}</td>
                    </tr>
                    <tr>
                        <td class=""table-row"">{{ImpactRowName}}</td>
                        <td class=""table-entry"">{{Impact}}</td>
                    </tr>
                    <tr>
                        <td class=""table-row"">{{HelpUrlRowName}}</td>
                        <td class=""table-entry""><a href=""{{HelpUrl}}"">{{HelpUrl}}</a></td>
                    </tr>
                    <tr>
                        <td class=""table-row"">{{TagsRowName}}</td>
                        <td class=""table-entry"">{{Tags}}</td>
                    </tr>
                </table>
                <br />
                {{#RuleNodes}}
                    {{> RuleNode}}
                {{/RuleNodes}}
            </section>
        ";

        internal static string RuleNode = @"
            <div class=""node-card"">
                <dl>
                    <dt class=""node-dt"">{{HTMLLabel}}</dt>
                    <dd>{{HTML}}</dd>
                </dl>
                <dl>
                    <dt class=""node-dt"">{{SelectorLabel}}</dt>
                    <dd>{{Selector}}</dd>
                </dl>
            </div>
            <br />
        ";
    }
}
