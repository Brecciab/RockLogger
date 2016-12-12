using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBed
{
    class OtherTestClass
    {
        [RockLogger.ValueLog]
        public int ErrorId { get; set; }

        [RockLogger.SerializeJSONLog]
        public Dictionary<string, string> DataBlock { get; set; }

        public OtherTestClass()
        {
            DataBlock = new Dictionary<string, string>()
            {
                { "First", "this" },
                { "Second", "that"},
                { "Third", "the other"}
            };
        }
    }
}
