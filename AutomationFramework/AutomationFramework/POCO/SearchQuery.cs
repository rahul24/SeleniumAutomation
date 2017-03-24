using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomationFramework.POCO
{
    public class SearchQuery
    {
        public string SearchField { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
        public bool IsValueCutom { get; set; }
    }
}
