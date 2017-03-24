using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Pages.Controls
{
    public interface IControl
    {
        bool Displayed { get; }
        bool Enabled { get; }
        bool Selected { get; }
        string TagName { get; }

        string Text { get; }

        void Clear();
        void Click();

        IControl FindElement(FindBy findby,string value);
        ReadOnlyCollection<IControl> FindElements(FindBy findby,string value);

        string GetAttribute(string attributeName);
        string GetCssValue(string propertyName);
        void SendKeys(string text);
        void Submit();
        void PressEnterKey();
        string InnerHTML { get; }
        string OuterHTML { get; }
    }
}
