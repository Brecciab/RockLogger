using RockLogger;
using DataAccess;
using AutoMapper;

namespace TestBed
{
    /// <summary>
    /// Sample of using Entity Framework writing
    /// </summary>
    public class LogWriterEF: RockLogger.IEventLog
    {
        public int Id { get; set; }

        public LogManager.EventLevel EventLevel { get; set; }

        public string MethodName { get; set; }

        public string ClassName { get; set; }

        public string SerializedData { get; set; }

        public string Message { get; set; }

        public string DataBlock { get; set; }

        public string ExceptionData { get; set; }

        [ValueLog]
        public string CompanyName { get; set; }

        [ValueLog]
        public int CompanyId { get; set; }

        public int ErrorId { get; set;}

        // Save the results to the data source
        public void Save()
        {            
            // This is where you would replace the "guts" with anything you wanted for writing
            // Create the object to save the values to
            using (var context = new EventSampleEntities())
            {
                // Use Automapper to map the fields 
                //Future: Change to static maps?                
                var config = new MapperConfiguration(cfg => cfg.CreateMap<LogWriterEF, EventActivity>());
                EventActivity ev = config.CreateMapper().Map<EventActivity>(this);
                ev.EventDate = System.DateTime.UtcNow;
                context.EventActivities.Add(ev);
                context.SaveChanges();
                
                Reset();
            }   
        }
        
        public void Reset()
        {
            //Future: Automate this!
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
