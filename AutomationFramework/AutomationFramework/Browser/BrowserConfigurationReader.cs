using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Browser
{
    internal class BrowserConfigurationReader
    {
        private static string testSupportBrowser = ConfigurationManager.AppSettings["TestSupportBrowser"] ?? "IE";
        private static string baseURL = ConfigurationManager.AppSettings["DefaultURL"] ?? "http://www.microsoft.com";
        private static string implicitwaitspan = ConfigurationManager.AppSettings["ImplicitWaitSpan"] ?? "30";
        private static string explicitwaitspan = ConfigurationManager.AppSettings["ExplicitWaitSpan"] ?? "30";
        internal static IList<string> TestSuportBrowsers()
        {
            return testSupportBrowser.Split(',').ToList();
        }

        internal static string BaseURL() { return baseURL; }
        internal static int ImplicitWaitSpan { get { return Convert.ToInt16(implicitwaitspan); } }
        internal static int ExplicitWaitSpan { get { return Convert.ToInt16(explicitwaitspan); } }
    }
}
