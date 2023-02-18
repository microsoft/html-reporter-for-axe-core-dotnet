// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace AxeCore.HTMLReporter.Templates
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

                    section.violation {
                        color: #CC6D6D;
                    }

                    hr.violation {
                        border-color: #CC6D6D;
                    }

                    table.violation {
                        color: #CC6D6D;
                    }
                </style>
            </head>
            <body>
                <h1>{{Title}}</h1>
                <br />
                <table>
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
                        <td class=""table-entry""><a href=""#{{ViolationsKey}}"">{{ViolationsCount}}</a></td>
                    </tr>
                    <tr>
                        <td class=""table-row"">{{PassesRowName}}</td>
                        <td class=""table-entry""><a href=""#{{PassesKey}}"">{{PassesCount}}</a></td>
                    </tr>
                    <tr>
                        <td class=""table-row"">{{IncompleteRowName}}</td>
                        <td class=""table-entry""><a href=""#{{IncompleteKey}}"">{{IncompleteCount}}</a></td>
                    </tr>
                    <tr>
                        <td class=""table-row"">{{InapplicableRowName}}</td>
                        <td class=""table-entry""><a href=""#{{InapplicableKey}}"">{{InapplicableCount}}</a></td>
                    </tr>
                </table>
                <br />
                {{#RuleGroups}}
                    {{> RuleGroup}}
                {{/RuleGroups}}
            </body>
        ";

        internal static string RuleGroup = @"
            <section id=""{{RuleGroupId}}"" class=""violation"">
                {{#Rules}}
                    {{> Rule}}
                {{/Rules}}
            </section>
        ";

        internal static string Rule = @"
            <hr class=""rule-divider violation"" />
            <section id=""{{RuleId}}"">
                <h2>{{RuleTitle}}</h2>
                <table class=""violation"">
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
