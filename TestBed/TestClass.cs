using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockLogger;

namespace TestBed
{
    public class TestClass
    {
        [Logger.ValueLog]
        public int CompanyId { get; set; }

        [Logger.ValueLog]
        public string CompanyName { get; set; }

        [Logger.ValueLog]
        //Example, you may want to set to the calling IP address if a WCF or some other identifying information
        public string ExeLocation { get; set; } = System.Reflection.Assembly.GetExecutingAssembly().Location;

        [Logger.SerializeJSONLog]
        public Dictionary<string, string> DataBlock { get; set; }

        [Logger.SerializeXMLLog]
        public Dictionary<string, string> XMLDataBlock { get; set; }


        public string CheckCompanyFacts()
        {
            string results = string.Empty;

            // Do stuff to set the results.  Usually check the DB, etc.
            CompanyId = 13;

            CompanyName = "Right Angle Technologies";

            DataBlock = new Dictionary<string, string>()
            {
                { "First", "this" },
                { "Second", "that"},
                { "Third", "the other"}
            };

            XMLDataBlock = new Dictionary<string, string>()
            {
                { "First", "XML1" },
                { "Second", "XML2"},
                { "Third", "XML3"}
            };

            return results;
        }
    }
}
