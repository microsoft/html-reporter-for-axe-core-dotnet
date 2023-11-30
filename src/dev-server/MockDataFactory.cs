// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Deque.AxeCore.Commons;
using Newtonsoft.Json.Linq;

namespace Microsoft.HtmlReporterForAxeCore.DevServer
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
                    Tags = new string[] { "cat.language", "wcag2a", "wcag311", "ACT" },
                    Impact = "Critical"
                },

                new AxeResultItem()
                {
                    Id = "label",
                    Description = "Ensures every form element has a label",
                    Help= "Form elements must have labels",
                    HelpUrl = "https://dequeuniversity.com/rules/axe/4.6/label",
                    Tags = new string[] { "cat.forms", "wcag2a", "wcag412", "section508", "section508.22.n", "ACT" },
                    Impact = "Serious"
                }
            };

            AxeResultItem[] passes = new AxeResultItem[]
            {
                new AxeResultItem()
                {
                    Id = "dlitem",
                    Description = "<dt> and <dd> elements must be contained by a <dl>",
                    Help= "Ensures <dt> and <dd> elements are contained by a <dl>",
                    HelpUrl = "https://dequeuniversity.com/rules/axe/4.1/dlitem",
                    Tags = new string[] { "cat.structure", "wcag2a", "wcag131" },
                    Impact = "Serious"
                },

                new AxeResultItem()
                {
                    Id = "image-alt",
                    Description = "Ensures <img> elements have alternate text or a role of none or presentation",
                    Help= "Images must have alternate text",
                    HelpUrl = "https://dequeuniversity.com/rules/axe/4.1/image-alt",
                    Tags = new string[] { "cat.text-alternatives", "wcag2a", "wcag111", "section508", "section508.22.a", "ACT" },
                    Impact = "Critical"
                }
            };

            AxeResultItem[] inapplicable = new AxeResultItem[]
            {
                new AxeResultItem()
                {
                    Id = "aria-input-field-name",
                    Description = "Ensures every ARIA input field has an accessible name",
                    Help= "ARIA input fields must have an accessible name",
                    HelpUrl = "https://dequeuniversity.com/rules/axe/4.1/aria-input-field-name",
                    Tags = new string[] { "cat.aria", "wcag2a", "wcag412", "ACT" },
                    Impact = ""
                }
            };

            AxeResultItem[] incomplete = new AxeResultItem[]
            {
                new AxeResultItem()
                {
                    Id = "document-title",
                    Description = "Ensures each HTML document contains a non-empty <title> element",
                    Help= "Documents must have <title> element to aid in navigation",
                    HelpUrl = "https://dequeuniversity.com/rules/axe/4.1/document-title",
                    Tags = new string[] { "cat.text-alternatives", "wcag2a", "wcag242", "ACT" },
                    Impact = "Serious"
                }
            };

            JObject resultJson = JObject.FromObject(new
            {
                url = "https://127.0.0.1",
                timestamp = DateTime.Now,
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
