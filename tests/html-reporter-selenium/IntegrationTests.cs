// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Deque.AxeCore.Commons;
using Deque.AxeCore.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AxeCore.HTMLReporter.Selenium.Tests
{
    [TestFixture]
    [Category("Integration")]
    public sealed class IntegrationTests
    {
        private IWebDriver m_webDriver;

        public IntegrationTests()
        {
            DriverManager driverManager = new();
            driverManager.SetUpDriver(new ChromeConfig(), "116.0");
        }

        [SetUp]
        public void SetupTest()
        {
            string chromeBinaryLocation = Environment.GetEnvironmentVariable("CHROMIUM_BIN");
            ChromeOptions options = new()
            {
                BinaryLocation = chromeBinaryLocation,
                BrowserVersion = "116"
            };
            options.AddArguments("--headless", "--no-sandbox");
            m_webDriver = new ChromeDriver(options);
        }

        [TearDown]
        public void TeardownTest()
        {
            m_webDriver.Close();
        }

        [Test]
        public void InvokingAnalyze_WithHtmlReport_ShouldGenerateHTMLReportFile()
        {
            NavigateToFile();

            AxeBuilder builder = new AxeBuilder(m_webDriver)
                .WithHTMLReport();

            AxeResult result = builder.Analyze();

            Assert.IsNotNull(result);

            // TODO IsaacWalker - Verify HTML Report file is present.
        }

        private void NavigateToFile(string file = "default-test-page.html")
        {
            string fullFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", file);

            if (!File.Exists(fullFilePath))
            {
                throw new FileNotFoundException($"File not found at {fullFilePath}");
            }

            Uri url = new($"file://{fullFilePath}");

            m_webDriver.Navigate().GoToUrl(url);
        }
    }
}
