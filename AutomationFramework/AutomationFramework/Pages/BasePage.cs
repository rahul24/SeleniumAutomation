using AutomationFramework.Pages.Controls;
using AutomationFramework.Pages.Navigation;


namespace AutomationFramework.Pages
{
    public class BasePage
    {
        private TopNavigation _topNavigation;
        private BottomNavigation _bottomNavigation;

        public TopNavigation TopNavigation { get { return _topNavigation; } set { _topNavigation = value; } }
        public BottomNavigation BottomNavigation { get { return _bottomNavigation; } set { _bottomNavigation = value; } }

        public virtual IControl PageControl { get; }

    }
}
