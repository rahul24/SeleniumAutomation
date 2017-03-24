using AutomationFramework.Pages.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace AutomationFramework.Pages
{
    public class LiveAuthentication:BasePage
    {
        [FindsBy(How = How.Name, Using = "loginfmt")]
        private IWebElement username;
        [FindsBy(How = How.Name, Using = "passwd")]
        private IWebElement password;
        [FindsBy(How = How.Id, Using = "idSIButton9")]
        private IWebElement signin;

        IControl userNameControl;
        public IControl UserName
        {
            get
            {
                if (userNameControl == null)
                    userNameControl = new Control(username);
                return userNameControl;
            }
        }

        IControl passwordControl;
        public IControl Password
        {
            get
            {
                if (passwordControl == null)
                    passwordControl = new Control(password);
                return passwordControl;
            }
        }

        IControl signinControl;
        public IControl SignIn
        {
            get
            {
                if (signinControl == null)
                    signinControl = new Control(signin);
                return signinControl;
            }
        }

        internal WebDriverWait WebWait { set; get; }

        internal void PopulateInput()
        {
            IDictionary<string, string> inputs = PageConfigurationReader.Read_LiveAuthentication_Input();

            if (inputs != null && inputs.Count > 0)
            {
                UserName.SendKeys(inputs["UserName"]);
                //username.SendKeys(Keys.Tab);
                Password.SendKeys(inputs["Password"]);

                //try
                //{
                //    Thread.Sleep(5000);
                //    IWebElement detetctError = WebWait.Until(ExpectedConditions.ElementIsVisible(By.Id("usernameError"))); //PageControl.FindElement(FindBy.Id, "alert alert-error col-md-24");
                //    if (detetctError != null)
                //        throw new System.Exception("Invalid Live Credentials");
                //}
                //catch { }         
            }
        }
    }
}
