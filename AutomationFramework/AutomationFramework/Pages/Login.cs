using AutomationFramework.Pages.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace AutomationFramework.Pages
{
    public class Login:BasePage
    {   
        [FindsBy(How = How.TagName, Using = "html")]
        private IWebElement pageControl;

        [FindsBy(How = How.XPath, Using = "//table[@id = 'mainContentPlaceHolder__CSRLogin__LoginButton']/tbody/tr/td/table/tbody/tr/td/a")]
        private IWebElement signinCSR;

        [FindsBy(How = How.LinkText, Using = "Sign in with your Microsoft Partner Domain Account")]
        private IWebElement signinPartnerDomain;

        [FindsBy(How = How.XPath, Using = "//table[@id='mainContentPlaceHolder__DomainLogin__LoginButton']/tbody/tr/td/table/tbody/tr/td/a")]            
        private IWebElement signinROC;

        [FindsBy(How = How.LinkText, Using = "Sign in with your Windows Live ID")]
        private IWebElement signinWLID;

        IControl pagecontrolitem;
        public override IControl PageControl
        {
            get
            {
                if (pagecontrolitem == null)
                    pagecontrolitem = new Control(pageControl);
                return pagecontrolitem;
            }
        }

        IControl signInCSRControl;
        public IControl SignInCSR
        {
            get
            {
                if (signInCSRControl == null)                
                    signInCSRControl = new Control(signinCSR);

                return signInCSRControl;
            }
        }

        IControl signinPartnerDomainControl;
        public IControl SignInPartnerDomain
        {
            get
            {
                if (signinPartnerDomainControl == null)
                    signinPartnerDomainControl = new Control(signinPartnerDomain);

                return signinPartnerDomainControl;
            }
        }

        IControl signinROCControl;
        public IControl SignInROC
        {
            get
            {
                if (signinROCControl == null)
                    signinROCControl = new Control(signinROC);                
                return signinROCControl;
            }
        }

        IControl signinWLIDControl;
        public IControl SignInWLID
        {
            get
            {
                if (signinWLIDControl == null)
                    signinWLIDControl = new Control(signinWLID);
                return signinWLIDControl;
            }
        }

        IDictionary<string, IControl> elementsFromConfig;
        public IDictionary<string, IControl> GetElementsFromConfig
        {
            get
            {
                if (elementsFromConfig == null)
                {
                    elementsFromConfig = new Dictionary<string, IControl>();
                    foreach (var item in PageConfigurationReader.ReadElementFindByControlIdInput())
                    {
                        try
                        {
                            elementsFromConfig.Add(item, new Control(pageControl.FindElement(By.Id(item))));
                        }
                        catch { elementsFromConfig.Add(item, null); }
                    }

                    foreach (var item in PageConfigurationReader.ReadElementFindByLinkTextInput())
                    {
                        try
                        {
                            elementsFromConfig.Add(item, new Control(pageControl.FindElement(By.LinkText(item))));
                        }
                        catch { elementsFromConfig.Add(item, null); }
                    }

                    foreach (var item in PageConfigurationReader.ReadElementFindByXPathInput())
                    {
                        try
                        {
                            elementsFromConfig.Add(item, new Control(pageControl.FindElement(By.XPath(item))));
                        }
                        catch { elementsFromConfig.Add(item, null); }
                    }
                }

                return elementsFromConfig;
            }
        }

        public void Goto()
        {
            //PageConfigurationReader.ReadTestInput();
            //this.TopNavigation.Home.Click();
        }

        internal WebDriverWait WebWait { set; get; } 

    }
}
