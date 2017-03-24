using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Browser
{
    public abstract class BaseBrowser
    {
        public abstract string BaseUrl { get;}
        internal abstract ISearchContext SearchDriver { get;}
        public abstract string Title { get; }
        public abstract void Goto(string url);
        internal abstract IWebDriver WebDriver { get; }        
        internal abstract WebDriverWait ExplicitWait { get; }
    }
}
