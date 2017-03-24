using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationFramework.Browser;
using AutomationFramework.Pages;

namespace WebAutomationTestSuite
{
    [TestClass]
    public class BaseTest
    {
        Browser browser;
        Pages pages;

        [TestInitialize]
        public void TestInitalizer()
        {
            browser = new Browser();
            browser.Initialize();
            pages = new Pages(browser);
        }

        [TestCleanup]
        public void Cleanup()
        {
            browser.Close();
        }       

        public Pages PageObject
        {
            get { return pages; }
        }
    }
}
