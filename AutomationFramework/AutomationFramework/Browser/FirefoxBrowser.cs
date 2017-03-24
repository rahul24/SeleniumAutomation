using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AutomationFramework.Browser
{
    public class FirefoxBrowser : BaseBrowser
    {
        private IWebDriver firefoxDriver = null;
        private WebDriverWait explicitWait = null;
        public FirefoxBrowser()
        {
            

            FirefoxProfile profile = new FirefoxProfile();                        
            firefoxDriver = new FirefoxDriver(profile);
            firefoxDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(BrowserConfigurationReader.ImplicitWaitSpan));
            explicitWait = new WebDriverWait(firefoxDriver, TimeSpan.FromSeconds(BrowserConfigurationReader.ExplicitWaitSpan));
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
                return (ISearchContext)firefoxDriver;
            }
        }

        internal override WebDriverWait ExplicitWait
        {
            get
            {
                return explicitWait;
            }
        }

        public override string Title
        {
            get
            {
                return firefoxDriver.Title;
            }
        }
        public override void Goto(string url)
        {
            firefoxDriver.Url = BaseUrl + url;
        }

        public void AuthenticationHandler(string username,string password)
        {
            IAlert a = explicitWait.Until(ExpectedConditions.AlertIsPresent());
            a.SetAuthenticationCredentials(username, password);
        }

        internal override IWebDriver WebDriver
        {
            get
            {
                return firefoxDriver;
            }
        }
    }
}
