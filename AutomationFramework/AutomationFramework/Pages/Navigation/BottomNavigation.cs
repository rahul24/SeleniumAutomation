using AutomationFramework.Pages.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace AutomationFramework.Pages.Navigation
{
    public class BottomNavigation
    {
        [FindsBy(How = How.LinkText, Using = "Contact Us")]
        private IWebElement contactusLink;

        [FindsBy(How = How.LinkText, Using = "eAgreements Terms of Use")]
        private IWebElement termsofuseLink;

        [FindsBy(How = How.LinkText, Using = "Trademarks")]
        private IWebElement trademarksLink;

        [FindsBy(How = How.LinkText, Using = "Privacy Statement")]
        private IWebElement privacyLink;

        public IControl ContactUs { get { return new Control(contactusLink); } }
        public IControl EagreementsTermsOfUse { get { return new Control(termsofuseLink); } }
        public IControl Trademarks { get { return new Control(trademarksLink); } }
        public IControl PrivacyStatment { get { return new Control(privacyLink); } }
    }
}
