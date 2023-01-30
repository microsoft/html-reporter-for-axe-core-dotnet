// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Deque.AxeCore.Commons;
using Newtonsoft.Json.Linq;

namespace AxeCore.HTMLReporter.DevServer
{
    public sealed class MockDataFactory
    {
        public static AxeResult CreateMockResultData()
        {
            AxeResultItem[] violations = new AxeResultItem[]
            {
                new AxeResultItem()
                {
                    Id = "html-has-lang",
                    Description = "Ensure every HTML document has a lang attribute",
                    Help= "<html> element must have a lang attribute",
                    HelpUrl = "https://dequeuniversity.com/rules/axe/4.6/html-has-lang",
                    Tags = new string[] { "cat.language", "wcag2a", "wcag311", "ACT" }
                },

                new AxeResultItem()
                {
                    Description = "Ensures every form element has a label",
                    Help= "Form elements must have labels",
                    HelpUrl = "https://dequeuniversity.com/rules/axe/4.6/label",
                    Tags = new string[] { "cat.forms", "wcag2a", "wcag412", "section508", "section508.22.n", "ACT" }
                }
            };

            AxeResultItem[] passes = new AxeResultItem[]
            {
            };

            AxeResultItem[] inapplicable = new AxeResultItem[]
            {
            };

            AxeResultItem[] incomplete = new AxeResultItem[]
            {};

            JObject resultJson = JObject.FromObject(new
            {
                url = "https://127.0.0.1",
                violations,
                passes,
                inapplicable,
                incomplete
            });

            AxeResult mockResult = new(resultJson);

            return mockResult;
        }
    }
}
