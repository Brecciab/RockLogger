using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace RockLogger
{
    //TODO: Probably need to fix for thread safety

        /// <summary>
        /// Using Class rather than reading from the config each time so that it can be changed on the fly
        /// </summary>
    public class Settings  
    {
        private static Settings instance;

        private Settings() {
            //Load the settings from the app.config on first run
            var section = ConfigurationManager.GetSection("RockLogger") as System.Collections.Specialized.NameValueCollection;
            CurrentLoggingLevel = (LogManager.EventLevel)Convert.ToInt32(section["CurrentLoggingLevel"]);
            LogFileLocation = section["LogFileLocation"];
            EventLogName = section["LogFileLocation"];
        }

        public string LogFileLocation { get; set; }

        public LogManager.EventLevel CurrentLoggingLevel { get; set; }

        public string EventLogName { get; set; }

        public static Settings Instance
        {
            get
            {
                if (instance == null)
                { instance = new Settings(); }
                return instance;
            }
                

        }
    }
}
