using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockLogger
{
    public interface IEventLog
    {
        int Id { get; set;}

        string MethodName { get; set;}

        string ClassName { get; set;}

        // This probably should be removed from the Interface
        string SerializedData { get; set; }

        string Message { get; set; }

        string ExceptionData { get; set; }

        LogManager.EventLevel EventLevel { get; set; }

        // Save the results to the data source
        void Save();

        void Reset();
        
    }
}
