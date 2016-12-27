using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBed
{
    //TODO: Probably need to fix for thread safety
    public class Utilities
    {
        private static Utilities instance;

        public List<ErrorItem> Errors { get; set; }

        private Utilities()
        {
            // Load the error messages from the resource file, check if the DB is available and errors should be rewritten.
            // Check if the database is responding.
            // If not then log the error
            // Check the DB if there is a new error message.  
            // If so, rewrite the resource file?    
        }

        public static Utilities Instance
        {
            get
            {
                if (instance == null)
                { instance = new Utilities(); }
                return instance;
            }
        }
    }
}
