using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;


namespace AutomationFramework.Browser
{
    public class IEBrowser : BaseBrowser
    {
        private IWebDriver ieDriver = null;
        private WebDriverWait explicitWait = null;

        public IEBrowser()
        {            
            InternetExplorerOptions o = new InternetExplorerOptions();
            o.IgnoreZoomLevel = true;
            //o.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            //o.EnsureCleanSession = true;
            //o.PageLoadStrategy = InternetExplorerPageLoadStrategy.Normal;
            //o.RequireWindowFocus = true;
            //InternetExplorerDriverService s = InternetExplorerDriverService.CreateDefaultService();
            //s.HideCommandPromptWindow = false;
            //s.LogFile = "IEDriver.log";
            //s.LoggingLevel = InternetExplorerDriverLogLevel.Debug;

            //DesiredCapabilities ieCapabilities = DesiredCapabilities.InternetExplorer();
            //ieCapabilities.SetCapability("nativeEvents", false);
            //ieCapabilities.SetCapability("unexpectedAlertBehaviour", "accept");
            //ieCapabilities.SetCapability("ignoreProtectedModeSettings", true);
            //ieCapabilities.SetCapability("disable-popup-blocking", true);
            //ieCapabilities.SetCapability("enablePersistentHover", true);

            //DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorer();
            //capabilities.SetCapability("requireWindowFocus", true);

            //o.AddAdditionalCapability("requireWindowFocus", true);
            //capabilities.SetCapability("nativeEvents", false);
            o.EnableNativeEvents = false;

            ieDriver = new InternetExplorerDriver(o);//new InternetExplorerDriver(); //
            //ieDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(260));
            ieDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(BrowserConfigurationReader.ImplicitWaitSpan));
            explicitWait = new WebDriverWait(ieDriver,TimeSpan.FromSeconds(BrowserConfigurationReader.ExplicitWaitSpan));
            //explicitWait.PollingInterval = TimeSpan.FromSeconds(60);           
            Goto("");           
        }

        internal override WebDriverWait ExplicitWait
        {
            get { return explicitWait; }
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
                return (ISearchContext)ieDriver;
            }           
        }

        internal override IWebDriver WebDriver
        {
            get
            {
                return ieDriver;
            }
        }

        public override string Title
        {
            get
            {
                return ieDriver.Title;
            }
        }
        public override void Goto(string url)
        {
            ieDriver.Url = BaseUrl + url;
        }       
    }
}
