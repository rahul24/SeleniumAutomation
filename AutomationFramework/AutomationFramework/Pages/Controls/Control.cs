using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace AutomationFramework.Pages.Controls
{
    public class Control : IControl
    {
        private IWebElement _webelement;

        public Control(IWebElement element)
        {
            if (element != null)
                _webelement = element;
            else
                throw new Exception("Invalid element");
        }

        public bool Displayed
        {
            get
            {
                return _webelement.Displayed;
            }
        }

        public bool Enabled
        {
            get
            {
                return _webelement.Enabled;
            }
        }        

        public bool Selected
        {
            get
            {
                return _webelement.Selected;
            }
        }        

        public string TagName
        {
            get
            {
                return _webelement.TagName;
            }
        }

        public string Text
        {
            get
            {
                return _webelement.Text;
            }
        }

        public void Clear()
        {
            _webelement.Clear();
        }

        public void Click()
        {
            _webelement.Click();
        }
        

        public IControl FindElement(FindBy findby,string value)
        {
            By criteria;
            switch (findby)
            {
                case FindBy.ClassName:
                    criteria = By.ClassName(value);
                    break;
                case FindBy.CssSelector:
                    criteria = By.CssSelector(value);
                    break;
                case FindBy.Id:
                    criteria = By.Id(value);
                    break;
                case FindBy.LinkText:
                    criteria = By.LinkText(value);
                    break;
                case FindBy.Name:
                    criteria = By.Name(value);
                    break;
                case FindBy.PartialLinkText:
                    criteria = By.PartialLinkText(value);
                    break;
                case FindBy.TagName:
                    criteria = By.TagName(value);
                    break;
                case FindBy.XPath:
                    criteria = By.XPath(value);
                    break;
                default:
                    criteria = By.Id(value);
                    break;
            }
            IControl control;
            try
            {
                
                control = new Control(_webelement.FindElement(criteria));
            }
            catch(Exception ex) { throw new Exception("Invalid element"); }

            return control;
        }
        

        public ReadOnlyCollection<IControl> FindElements(FindBy findby,string value)
        {
            By criteria;
            switch (findby)
            {
                case FindBy.ClassName:
                    criteria = By.ClassName(value);
                    break;
                case FindBy.CssSelector:
                    criteria = By.CssSelector(value);
                    break;
                case FindBy.Id:
                    criteria = By.Id(value);
                    break;
                case FindBy.LinkText:
                    criteria = By.LinkText(value);
                    break;
                case FindBy.Name:
                    criteria = By.Name(value);
                    break;
                case FindBy.PartialLinkText:
                    criteria = By.PartialLinkText(value);
                    break;
                case FindBy.TagName:
                    criteria = By.TagName(value);
                    break;
                case FindBy.XPath:
                    criteria = By.XPath(value);
                    break;
                default:
                    criteria = By.Id(value);
                    break;
            }

            ReadOnlyCollection<IWebElement> collection = null;
            ReadOnlyCollection<IWebElement> filtercollection = null;
            try
            {
                collection = _webelement.FindElements(criteria);

                if (collection != null)
                {
                    IList<IWebElement> tmp = new List<IWebElement>();
                    foreach (var item in collection)
                    {
                        try
                        {
                            if (!string.IsNullOrWhiteSpace(item.TagName))
                                tmp.Add(item);
                        }
                        catch(StaleElementReferenceException e) { }
                    }

                    filtercollection = new ReadOnlyCollection<IWebElement>(tmp);
                }
            }
            catch (Exception ex) { throw new Exception("Invalid element"); }

            IList<IControl> wrapCollection = new List<IControl>();
            
            foreach (var item in filtercollection)
            {
                wrapCollection.Add(new Control(item));
            }

            return new ReadOnlyCollection<IControl>(wrapCollection);
        }

        public string GetAttribute(string attributeName)
        {
            return _webelement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return _webelement.GetCssValue(propertyName);
        }

        public void SendKeys(string text)
        {
            _webelement.SendKeys(text);
        }

        public void Submit()
        {
            _webelement.Submit();
        }
        
        public void PressEnterKey()
        {
            _webelement.SendKeys(Keys.Enter);
        }

        public string OuterHTML
        {
            get
            {
                return _webelement.GetAttribute("outerHTML");
            }
        }

        public string InnerHTML
        {
            get
            {
                return _webelement.GetAttribute("innerHTML");
            }
        }

        internal IWebElement WebElement
        {
            get { return _webelement; }
        }
    }
}
