// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.Extensions.FileProviders;
using RazorEngineCore;
using System;
using System.IO;

namespace AxeCore.HTMLReporter
{
    /// <inheritdoc />
    public sealed class AxeHTMLReporter : IAxeHTMLReporter
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static AxeHTMLReporter Instance { get; }

        private readonly IFileProvider m_embeddedFileProvider;

        private readonly IRazorEngine m_razorEngine;

        static AxeHTMLReporter()
        {
            IFileProvider embeddedFileProvider = new EmbeddedFileProvider(typeof(AxeHTMLReporter).Assembly);
            IRazorEngine razorEngine = new RazorEngine();
            Instance = new AxeHTMLReporter(embeddedFileProvider, razorEngine);
        }

        internal AxeHTMLReporter(IFileProvider embeddedFileProvider, IRazorEngine razorEngine)
        {
            m_embeddedFileProvider = embeddedFileProvider;
            m_razorEngine = razorEngine;
        }

        /// <inheritdoc />
        public AxeHTMLReport CreateReport(object results, AxeHTMLReportOptions options = null)
        {
            string reportTemplateContent = GetContent("Content/Report.cshtml");

            IRazorEngineCompiledTemplate template = m_razorEngine.Compile(reportTemplateContent, builder => {
                builder.AddAssemblyReference(typeof(DateTime));
            });
            string htmlReport = template.Run();

            return new AxeHTMLReport(htmlReport);
        }

        private string GetContent(string name)
        {
            IFileInfo report = m_embeddedFileProvider.GetFileInfo(name);
            return new StreamReader(report.CreateReadStream()).ReadToEnd();
        }
    }
}
