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
                </style>
            </head>
            <body>
                <h1>{{Title}}</h1>
                <br />
                <table>
                    <tr>
                        <td>{{TestUrlRowName}}</td>
                        <td>{{TestUrl}}</td>
                    </tr>
                    <tr>
                        <td>{{TimestampRowName}}</td>
                        <td>{{Timestamp}}</td>
                    </tr>
                    <tr>
                        <td>{{ViolationsRowName}}</td>
                        <td><a href=""#{{ViolationsKey}}"">{{ViolationsCount}}</a></td>
                    </tr>
                    <tr>
                        <td>{{PassesRowName}}</td>
                        <td><a href=""#{{PassesKey}}"">{{PassesCount}}</a></td>
                    </tr>
                    <tr>
                        <td>{{IncompleteRowName}}</td>
                        <td><a href=""#{{IncompleteKey}}"">{{IncompleteCount}}</a></td>
                    </tr>
                    <tr>
                        <td>{{InapplicableRowName}}</td>
                        <td><a href=""#{{InapplicableKey}}"">{{InapplicableCount}}</a></td>
                    </tr>
                </table>
                <br />
                {{#RuleGroups}}
                    {{> RuleGroup}}
                {{/RuleGroups}}
            </body>
        ";

        internal static string RuleGroup = @"
            <section id=""{{RuleGroupId}}"">
                {{#Rules}}
                    {{> Rule}}
                {{/Rules}}
            </section>
        ";

        internal static string Rule = @"
            <hr />
            <section id=""{{RuleId}}"">
                <h2>{{RuleTitle}}</h2>
                <table>
                    <tr>
                        <td>{{ImpactRowName}}</td>
                        <td>{{Impact}}</td>
                    </tr>
                    <tr>
                        <td>{{HelpUrlRowName}}</td>
                        <td><a href=""{{HelpUrl}}"">{{HelpUrl}}</a></td>
                    </tr>
                    <tr>
                        <td>{{TagsRowName}}</td>
                        <td>{{Tags}}</td>
                    </tr>
                </table>
                <br />
                {{#RuleNodes}}
                    {{> RuleNode}}
                {{/RuleNodes}}
            </section>
        ";

        internal static string RuleNode = @"
            <div>
                <dl>
                    <dt>{{HTMLLabel}}</dt>
                    <dd>{{HTML}}</dd>
                </dl>
                <dl>
                    <dt>{{SelectorLabel}}</dt>
                    <dd>{{Selector}}</dd>
                </dl>
            </div>
        ";
    }
}
