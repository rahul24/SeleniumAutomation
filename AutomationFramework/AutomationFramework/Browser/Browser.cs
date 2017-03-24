using OpenQA.Selenium;
using System.Collections.Generic;


namespace AutomationFramework.Browser
{
    public  class Browser
    {        
        IDictionary<string,BaseBrowser> _instanceCollection = new Dictionary<string, BaseBrowser>();
        
         
        public void Initialize()
        {
            IList<string> testSupportbrowser = BrowserConfigurationReader.TestSuportBrowsers();           

            foreach (var item in testSupportbrowser)
            {
                if(item.ToLower().Equals("ie") || item.ToLower().Contains("internet explorer"))
                {
                    _instanceCollection.Add(BrowserType.IE,new IEBrowser());
                }
                else if (item.ToLower().Equals("firefox") || item.ToLower().Contains("mozilla"))
                {
                    _instanceCollection.Add(BrowserType.Firefox,new FirefoxBrowser());
                }
                else if (item.ToLower().Equals("chrome") || item.ToLower().Contains("Google"))
                {
                    _instanceCollection.Add(BrowserType.Chrome,new ChromeBrowser());
                }
            }           
        }       

        public IDictionary<string, BaseBrowser> Instances
        {
            get { return _instanceCollection; }
        }

        public void Close()
        {
            foreach (var item in _instanceCollection.Values)
            {
                ((IWebDriver)item.SearchDriver).Quit();
            }

            _instanceCollection.Clear();
        }


    }
}
