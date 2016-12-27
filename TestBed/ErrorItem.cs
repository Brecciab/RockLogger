using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBed
{
    [Serializable()]
    public class ErrorItem
    {
        // May use a straight int because of database but for now this
        public enum ErrorActionId
        {
            Other = 0,
            OkOnly = 1,
            OkSubmit = 2,
            OkCancel = 3    // currently not implemented
        }

        public int Number { get; set; }
        public string Title { get; set; }
        public string DisplayMessage { get; set; }
        public ErrorActionId Action { get; set; }
        public string VideoLink { get; set; }
        public string HelpLink { get; set; }
    }
}
