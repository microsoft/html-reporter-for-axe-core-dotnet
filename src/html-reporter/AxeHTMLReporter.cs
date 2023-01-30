// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using AxeCore.HTMLReporter.Models;
using Deque.AxeCore.Commons;
using Microsoft.Extensions.FileProviders;
using RazorEngineCore;
using System;
using System.Globalization;
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
        public AxeHTMLReport CreateReport(AxeResult results, AxeHTMLReportOptions options = null)
        {
            string reportTemplateContent = GetContent("Content/Report.cshtml");

            IRazorEngineCompiledTemplate template = m_razorEngine.Compile(reportTemplateContent, builder =>
            {
                builder.AddAssemblyReference(typeof(ReportViewModel));
                builder.AddAssemblyReference(typeof(CultureInfo));
                builder.AddAssemblyReference(typeof(DateTime));
                builder.AddAssemblyReference(typeof(AxeResult));
            });

            CultureInfo language = CultureInfo.CurrentCulture;

            ReportViewModel viewModel = new ReportViewModel(language, results);
            string htmlReport = template.Run(viewModel);

            return new AxeHTMLReport(htmlReport);
        }

        private string GetContent(string name)
        {
            IFileInfo report = m_embeddedFileProvider.GetFileInfo(name);
            return new StreamReader(report.CreateReadStream()).ReadToEnd();
        }
    }
}
