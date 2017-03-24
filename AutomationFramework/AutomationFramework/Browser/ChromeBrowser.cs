using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using System.IO;
using System.Security.Policy;

namespace AutomationFramework.Browser
{
    public class ChromeBrowser : BaseBrowser
    {
        private IWebDriver chromeDriver = null;
        private WebDriverWait explicitwait = null;
        public ChromeBrowser()
        {
            chromeDriver = new ChromeDriver(System.Environment.CurrentDirectory);
            chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(BrowserConfigurationReader.ImplicitWaitSpan));
            explicitwait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(BrowserConfigurationReader.ExplicitWaitSpan));
            Goto("");           

        }

        public override string BaseUrl
        {
            get
            {
                return BrowserConfigurationReader.BaseURL();
            }            
        }

        internal override ISearchContext SearchDriver
        {
            get
            {
                return (ISearchContext)chromeDriver;
            }
        }

        internal override WebDriverWait ExplicitWait
        {
            get
            {
                return explicitwait;
            }
        }
        

        public override string Title
        {
            get
            {
                return chromeDriver.Title;
            }
        }
        public override void Goto(string url)
        {
            chromeDriver.Url = BaseUrl + url;
        }

        internal override IWebDriver WebDriver
        {
            get
            {
                return chromeDriver;
            }
        }

    }
}
