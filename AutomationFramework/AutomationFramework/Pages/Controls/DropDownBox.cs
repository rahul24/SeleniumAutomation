using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace AutomationFramework.Pages.Controls
{
    public class DropDownBox
    {
        private SelectElement _selectelement;

        internal DropDownBox(IWebElement element)
        {
            _selectelement = new SelectElement(element);
        }

        public DropDownBox(IControl element)
        {
            _selectelement = new SelectElement(((Control)element).WebElement);
        }

        IList<IControl> allselectedoption = new List<IControl>();
        public IList<IControl> AllSelectedOptions
        {
            get
            {
                if (allselectedoption == null)
                {
                    foreach (var item in _selectelement.AllSelectedOptions)
                    {
                        allselectedoption.Add(new Control(item));
                    }
                }
                return allselectedoption;
            }
        }        
        public bool IsMultiple { get { return _selectelement.IsMultiple; } }

        IList<IControl> options = null;
        public IList<IControl> Options
        {
            get
            {
                if (options == null)
                {
                    options = new List<IControl>();
                    foreach (var item in _selectelement.Options)
                    {
                        options.Add(new Control(item));
                    }
                }
                return options;
            }
        }

        IControl selectedoption = null;
        public IControl SelectedOption
        {
            get
            {
                if (selectedoption == null)
                    selectedoption = new Control(_selectelement.SelectedOption);
                return selectedoption;
            }
        }        
        public void DeselectAll() { _selectelement.DeselectAll(); }        
        public void DeselectByIndex(int index) { _selectelement.DeselectByIndex(index); }        
        public void DeselectByText(string text) { _selectelement.DeselectByText(text); }
        public void DeselectByValue(string value) { _selectelement.DeselectByValue(value); }
        public void SelectByIndex(int index) { _selectelement.SelectByIndex(index); }        
        public void SelectByText(string text) { _selectelement.SelectByText(text); }        
        public void SelectByValue(string value) { _selectelement.SelectByValue(value); }
    }

}
