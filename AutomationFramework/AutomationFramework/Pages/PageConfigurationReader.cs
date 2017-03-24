using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using WebAutomationFramework.POCO;

namespace AutomationFramework.Pages
{
    public class PageConfigurationReader
    {
        private static string _inputXML =  Convert.ToString(ConfigurationManager.AppSettings["InputXML"]);

        public static List<SearchQuery> Read_AdvancedSearchPage_SearchQueryBuilder_Input()
        {
            XElement xml = GetRootElement();

            List<SearchQuery> value = new List<SearchQuery>();
            if (xml.Element("SearchQueryBuilder") != null)
            {
                value = (from el in xml.Element("SearchQueryBuilder").Elements("SearchQuery")
                         where el != null
                         select new SearchQuery
                         {
                             SearchField = el.Element("SearchField").Value,
                             Operator = el.Element("Operator").Value,
                             Value = el.Element("Value").Value,
                             IsValueCutom = el.Element("Value").HasAttributes ?Convert.ToBoolean(el.Element("Value").Attribute("IsCustom").Value) : false
                         }).ToList();
            }

            return value;
        }

        public static IDictionary<string, string> Read_LiveAuthentication_Input()
        {
            XElement xml = GetRootElement();

            Dictionary<string, string> value = new Dictionary<string, string>();
            if (xml.Name.LocalName.Equals("LiveAuthentication"))
                value = (from el in xml.Descendants()
                         select new
                         {
                             Name = el.Name.LocalName,
                             Value = el.Value
                         }).ToDictionary(o => o.Name, o => o.Value);

            return value;
        }


        public static IList<string> ReadElementFindByControlIdInput()
        {
            XElement xml = GetRootElement();

            IList<string> value = new List<string>();
            if (xml.Element("FindByControlId") != null)
                value = (from el in xml.Element("FindByControlId").Descendants()
                         select el.Value
                         ).ToList<string>();

            return value;
        }

        public static IList<string> ReadElementFindByLinkTextInput()
        {
            XElement xml = GetRootElement();

            IList<string> value = new List<string>();
            if (xml.Element("FindByLinkText") != null)
                value = (from el in xml.Element("FindByLinkText").Descendants()
                         select el.Value
                         ).ToList<string>();

            return value ?? new List<string>(); ;
        }

        public static IList<string> ReadElementFindByXPathInput()
        {
            XElement xml = GetRootElement();

            IList<string> value = new List<string>();
            if (xml.Element("FindByLinkText") != null)
                value = (from el in xml.Element("FindByXPath").Descendants()
                         select el.Value
                         ).ToList<string>();

            return value ?? new List<string>(); ;
        }

        private static XElement GetRootElement()
        {
            XElement xml = XElement.Load(_inputXML);
            var result = (from e in xml.Elements("TestCase")
                          where e.Attribute("Name").Value.Equals(Utility.GetParentMethod())
                          select e.Element(Utility.GetPageName())).FirstOrDefault();
            return result??new XElement("Root");
        }

        public static IDictionary<string, IDictionary<string, string>> BuildAdvancedSearchOptions()
        {
            XElement xml = XElement.Load("AdvancedSearch_Control_Options.xml");
            IDictionary<string, IDictionary<string, string>> result = new Dictionary<string, IDictionary<string, string>>();
            result.Add("PackageStatus", GetOptions(xml, "PackageStatus"));
            result.Add("BillToCountry", GetOptions(xml, "BillToCountry"));
            result.Add("OperationsCenter", GetOptions(xml, "OperationsCenter"));
            return result;
        }

        private static IDictionary<string, string> GetOptions(XElement xml,string tag)
        {
            var result = (from e in xml.Elements(tag)
                              //where e.Attribute("Name").Value.Equals(Utility.GetParentMethod())
                          select e).FirstOrDefault();

            var value = (from el in result.Elements("ValueField")
                         select new
                         {
                             Name = el.Element("Key").Value,
                             Value = el.Element("Value").Value
                         }).ToDictionary(o => o.Name, o => o.Value);

            return value ?? new Dictionary<string, string>();
        }

        private static IDictionary<string,string> ConvertXMLToDictionary(XElement xml)
        {
            var value = (from el in xml.Descendants()
                         select new
                         {
                             Name = el.Name.LocalName,
                             Value = el.Value
                         }).ToDictionary(o => o.Name, o=> o.Value);

            return value??new Dictionary<string, string>();
        }
    }
}
