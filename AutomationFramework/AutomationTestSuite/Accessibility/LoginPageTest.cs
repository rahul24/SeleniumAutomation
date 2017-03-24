using AutomationFramework.Pages.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace WebAutomationTestSuite.Accessibility
{
    [TestClass]
    public class LoginPageTest : BaseTest
    {

        #region VSTF# 1064023   Use the LANG attribute to identify the language of the page.
        /// <summary>
        /// Make sure page is rendering with proper LANG value for EN-US and other languages
        /// </summary>
        [TestMethod]
        public void CheckLangAttributeExsits()
        {
            var loginpages = PageObject.LoginPage;

            foreach (var item in loginpages.Values)
            {
                Assert.AreNotEqual(string.Empty, item.PageControl.GetAttribute("lang"));
            }
        }
        #endregion

        #region VSTF# 1064030   Duplicate page title  and Document title must not be blank.
        /// <summary>
        /// Make sure page head has single occurrence of <title> with the value eAgreements
        /// </summary>
        [TestMethod]
        public void CheckForDuplicateTitles()
        {
            var loginpages = PageObject.LoginPage;
            foreach (var item in loginpages.Values)
            {
                ReadOnlyCollection<IControl> titles = item.PageControl.FindElements(FindBy.TagName, "title");
                Assert.AreEqual(1, titles.Count);
            }
        }
        

        /// <summary>
        /// Make sure page head has single occurrence of <title> with the value eAgreements
        /// </summary>
        [TestMethod]
        public void CheckTitleTextNonEmtpty()
        {
            var loginpages = PageObject.LoginPage;
            foreach (var item in loginpages.Values)
            {
                ReadOnlyCollection<IControl> titles = item.PageControl.FindElements(FindBy.TagName, "title");

                foreach(IControl title in titles)
                {
                    Assert.AreNotEqual(string.Empty, title.InnerHTML);
                }
            }
        }




        #endregion

        #region VSTF# 1050763   Check landmarks are present
        /// <summary>
        /// Make sure page is having 3 landmarks
        /// TODO: Check individual Landmarks one by one (navigation, main, footer)
        /// </summary>
        [TestMethod]
        public void CheckLandmarksCount()
        {
            var loginpages = PageObject.LoginPage;
            foreach (var item in loginpages.Values)
            {
                ReadOnlyCollection<IControl> roles = item.PageControl.FindElements(FindBy.XPath, "//div[@role]");
                Assert.AreEqual(3, roles.Count);
            }
        }
        #endregion


        #region VSTF# 1064029   Headings should not be empty
        /// <summary>
        /// Make sure all <h1 class="LoginPanelTitle"> are not empty
        /// </summary>
        [TestMethod]
        public void NoHeadingsWithEmptyText()
        {
            var loginpages = PageObject.LoginPage;
            foreach (var item in loginpages.Values)
            {
                ReadOnlyCollection<IControl> headings = item.PageControl.FindElements(FindBy.XPath, "//h1[@class='LoginPanelTitle']");

                foreach(IControl heading in headings)
                {
                    Assert.AreNotEqual(string.Empty, heading.Text);
                }
            }
        }
        #endregion

        #region VSTF# 1050761   Check alt for Decorative Images
        /// <summary>
        /// Make sure all 3 separator images have alt=""        
        /// </summary>
        [TestMethod]
        public void CheckAttributeAltForDecorativeImages()
        {
            var loginpages = PageObject.LoginPage;
            foreach (var item in loginpages.Values)
            {
                ReadOnlyCollection<IControl> images = item.PageControl.FindElements(FindBy.XPath, "//img[@src='Images/footerlink_seperator.gif']");
                foreach(IControl image in images)
                {
                    string altText = image.GetAttribute("alt");
                    Assert.AreEqual(string.Empty, altText);
                }
            }
        }
        #endregion

    }
}
