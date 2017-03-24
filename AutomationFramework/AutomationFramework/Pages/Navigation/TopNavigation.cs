using AutomationFramework.Pages.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace AutomationFramework.Pages.Navigation
{
    public class TopNavigation
    {
        [FindsBy(How = How.LinkText, Using = "Invite User")]
        private IWebElement inviteuserLink;

        [FindsBy(How = How.LinkText, Using = "Home")]
        private IWebElement homeLink;

        [FindsBy(How = How.LinkText, Using = "Download Smart Client")]
        private IWebElement downloadsmartclientLink;

        [FindsBy(How = How.LinkText, Using = "Manage Organizations")]
        private IWebElement manageOrganizationsLink;

        [FindsBy(How = How.LinkText, Using = "Help")]
        private IWebElement helpLink;

        [FindsBy(How = How.LinkText, Using = "Log out")]
        private IWebElement logOutLink;


        public IControl InviteUser { get { return new Control(inviteuserLink); } }
        public IControl Home { get { return new Control(homeLink); } }
        public IControl DownloadSmartClient { get { return new Control(downloadsmartclientLink); } }
        public IControl ManageOrganizations { get { return new Control(manageOrganizationsLink); } }
        public IControl Help { get { return new Control(helpLink); } }
        public IControl LogOut { get { return new Control(logOutLink); } }
    }
}
