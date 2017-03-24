using AutomationFramework.Browser;
using AutomationFramework.Pages.Navigation;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace AutomationFramework.Pages
{
    public class Pages
    {
        AutomationFramework.Browser.Browser _browser;

        public Pages(AutomationFramework.Browser.Browser browser)
        {
            _browser = browser;
        }

        /// <summary>
        /// Get Main Pages.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private IDictionary<string, T> GetPages<T>() where T : new()
        {
            IDictionary<string, T> pages = new Dictionary<string, T>();
            //Page Creation unit.
            foreach (var item in _browser.Instances.Values)
            {
                var page = new T();
                PageFactory.InitElements(item.SearchDriver, page);
                if (item.GetType().Equals(typeof(Browser.IEBrowser)))
                    pages.Add(BrowserType.IE, page);
                else if (item.GetType().Equals(typeof(Browser.FirefoxBrowser)))
                    pages.Add(BrowserType.Firefox, page);
                else if (item.GetType().Equals(typeof(Browser.ChromeBrowser)))
                    pages.Add(BrowserType.Chrome, page);
            }
            return pages;
        }

        /// <summary>
        /// Get Menu Pages.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page"></param>
        private  void GetSubPages<T>(IDictionary<string, T> pages) where T : BasePage
        {
            IDictionary<string, TopNavigation> topNavPages = GetPages<TopNavigation>();
            IDictionary<string, BottomNavigation> bottomNavPages = GetPages<BottomNavigation>();

            Parallel.ForEach(pages, item =>
            {
                if (item.Key.Equals(BrowserType.IE))
                {
                    item.Value.TopNavigation = topNavPages.FirstOrDefault(x => x.Key.Equals(BrowserType.IE)).Value;
                    item.Value.BottomNavigation = bottomNavPages.FirstOrDefault(x => x.Key.Equals(BrowserType.IE)).Value;                    
                }
                else if (item.Key.Equals(BrowserType.Firefox))
                {
                    item.Value.TopNavigation = topNavPages.FirstOrDefault(x => x.Key.Equals(BrowserType.Firefox)).Value;
                    item.Value.BottomNavigation = bottomNavPages.FirstOrDefault(x => x.Key.Equals(BrowserType.Firefox)).Value;
                }
                else if (item.Key.Equals(BrowserType.Chrome))
                {
                    item.Value.TopNavigation = topNavPages.FirstOrDefault(x => x.Key.Equals(BrowserType.Chrome)).Value;
                    item.Value.BottomNavigation = bottomNavPages.FirstOrDefault(x => x.Key.Equals(BrowserType.Chrome)).Value;
                }
            });          
        }


        void CheckURLIsCorrect(string pagename)
        {
            foreach (var item in _browser.Instances.Values)
            {
                if (!item.WebDriver.Url.ToLower().Contains(pagename.ToLower()))
                    throw new Exception("Invalid Page");
            }
        }

        /// <summary>
        /// Login Page.
        /// </summary>
        public IDictionary<string, Login> LoginPage
        {
            get
            {
                CheckURLIsCorrect("Login");
                IDictionary<string, Login> loginPages = GetPages<Login>();
                GetSubPages(loginPages);                
                return loginPages;
            }
        }    
        

        /// <summary>
        /// Live Authentication Page.
        /// Note: If auto populate functionality has any lag then refer - [Instructions\Setup.txt].         
        /// </summary>
        public IDictionary<string, LiveAuthentication> LiveAuthenticationPage
        {
            get
            {
                CheckURLIsCorrect("live");
                IDictionary<string, LiveAuthentication> liveauthPage = GetPages<LiveAuthentication>();
                foreach (var item in liveauthPage)
                {
                    item.Value.PopulateInput();
                }

                return liveauthPage;
            }
        }

        public void PageWaitByControlID(string controlId)
        {
            foreach (var item in _browser.Instances.Values)
            {
                if (!string.IsNullOrWhiteSpace(controlId))
                    item.ExplicitWait.Until(ExpectedConditions.ElementExists(ByAll.Id(controlId)));
            }
        }

        public void PageWaitBySpan(int millisecond)
        {
            foreach (var item in _browser.Instances.Values)
            {
                Thread.Sleep(millisecond);
            }
        }

        public void WaitForAjaxAction(Action<string> action,string param)
        {
            action.Invoke(param);
            Thread.Sleep(5000);
        }


        /// <summary>
        /// Hold the processing until page is fully loaded.
        /// </summary>
        /// <param name="driver"></param>
        private void WaitForPageToLoad()
        {
            TimeSpan timeout = new TimeSpan(0, 0, 30);

            foreach (var webdriver in _browser.Instances.Values)
            {
                WebDriverWait wait = new WebDriverWait(webdriver.WebDriver, timeout);

                IJavaScriptExecutor javascript = webdriver.WebDriver as IJavaScriptExecutor;
                if (javascript == null)
                    throw new ArgumentException("driver", "Driver must support javascript execution");

                wait.Until((d) =>
                {
                    try
                    {
                        string readyState = javascript.ExecuteScript("if (document.readyState) return document.readyState;").ToString();
                        return readyState.ToLower() == "complete";
                    }
                    catch (InvalidOperationException e)
                    {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                    }
                    catch (WebDriverException e)
                    {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
            }
        }
        public void Popuphandle(PopupButtonType type)
        {
            foreach (var webdriver in _browser.Instances.Values)
            {
                switch(type)
                {
                    case PopupButtonType.Accept:
                        webdriver.WebDriver.SwitchTo().Alert().Accept();
                        break;
                    case PopupButtonType.Decline:
                        webdriver.WebDriver.SwitchTo().Alert().Dismiss();
                        break;
                }
            }
        }

        public enum PopupButtonType
        {
            Accept,
            Decline
        }
    }
}

