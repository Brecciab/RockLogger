using RockLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBed
{
    class LogWriterTxt : RockLogger.IEventLog
    {
        public int Id { get; set; }

        public LogManager.EventLevel EventLevel { get; set; }

        public string MethodName { get; set; }

        public string ClassName { get; set; }

        public string SerializedData { get; set; }

        public string Message { get; set; }

        public string DataBlock { get; set; }

        public string ExceptionData { get; set; }

        [Logger.ValueLog]
        public string CompanyName { get; set; }

        [Logger.ValueLog]
        public int CompanyId { get; set; }

        // Save the results to the data source
        public void Save()
        {
            //TODO: Finish this method
        }

        public void Reset()
        {
            // Reset all the base parameters
            Id = 0;
            EventLevel = LogManager.EventLevel.Information;
            MethodName = string.Empty;
            ClassName = string.Empty;
            SerializedData = string.Empty;
            Message = string.Empty;
            DataBlock = string.Empty;
            ExceptionData = string.Empty;
            CompanyName = string.Empty;
            CompanyId = 0;
        }
    }
}
