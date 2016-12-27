using System;
using System.Reflection;
using RockLogger;
using System.Configuration;
using System.Xml.Serialization;

namespace RockLogger
{
    public partial class LogManager
    {
        public enum EventLevel
        {
            Off = 0,
            Debug  = 1,
            Information = 2,
            Error = 3,  // Error that is caught without exception
            CriticalError = 4, // Error with Exception
            All = 5 // All messages will be logged
        }

        private RockLogger.Settings settings = Settings.Instance;

        /// <summary>
        /// Checks if the level of the message is set to be logged
        /// </summary>
        /// <returns>True means proceed with logging</returns>
        public static bool CheckLoggingLevel(LogManager.EventLevel level  )
        {
            if (Settings.Instance.CurrentLoggingLevel >= level  || Settings.Instance.CurrentLoggingLevel == EventLevel.All)
            {
                return true;
            }
            else
            {
                return false;
            }
            //Future: Also want to include or exclude based on namespace
        }
        
        /// <summary>
        /// Writes a simple debug statement with no other data saved.  
        /// </summary>
        /// <param name="eventLog">The object used to save the data</param>
        /// <param name="methodBase">The calling methods information for reflection</param>
        /// <param name="Message">A manually set message</param>
        public static void WriteDebugEvent(IEventLog eventLog, MethodBase methodBase, string Message)
        {
            if (CheckLoggingLevel(EventLevel.Debug))
            {
                // get the method name
                eventLog.MethodName = methodBase.Name.ToString();
                // Get the name of the class that is calling
                eventLog.ClassName = methodBase.Module.ToString();

                eventLog.EventLevel = LogManager.EventLevel.Debug;

                //Only the main information will be logged here since this is typically called by a static method                     
                eventLog.Save();
            }  
        }

        /// <summary>
        /// Log a debug event with parameters from the object array added
        /// </summary>
        /// <param name="eventLog">The object used to save the data</param>
        /// <param name="methodBase">The calling methods information for reflection</param>
        /// <param name="Message">A manually set message</param>
        /// <param name="ob">Array of objects to set the parameters for on the event log object</param>
        public static void WriteDebugEvent(IEventLog eventLog, MethodBase methodBase, string Message, params object[] ob)
        {
            if (CheckLoggingLevel(EventLevel.Debug))
            {
                // get the method name
                eventLog.MethodName = methodBase.Name.ToString();
                // Get the name of the class that is calling
                eventLog.ClassName = methodBase.Module.ToString();

                eventLog.EventLevel = LogManager.EventLevel.Debug;

                SetAttributeValues(eventLog, ob);

                eventLog.Save();
            }
        }

        /// <summary>
        /// Log a Critical error event with parameters from the object array added
        /// </summary>
        /// <param name="eventLog"></param>
        /// <param name="methodBase"></param>
        /// <param name="exp"></param>
        /// <param name="ob">Array of objects to set the parameters for on the event log object</param>
        public static void WriteCriticalErrorEvent(IEventLog eventLog, MethodBase methodBase, Exception exp, params object[] ob)
        {
            if (CheckLoggingLevel(EventLevel.CriticalError))
            {
                // get the method name
                eventLog.MethodName = methodBase.Name.ToString();
                // Get the name of the class that is calling
                eventLog.ClassName = methodBase.Module.ToString();

                eventLog.EventLevel = LogManager.EventLevel.CriticalError;

                eventLog.ExceptionData = exp.Data.ToString();

                eventLog.Message = exp.Message;

                SetAttributeValues(eventLog, ob);

                eventLog.Save();
            }
        }

        /// <summary>
        /// Log event while specifying the log level manually
        /// </summary>
        /// <param name="level"></param>
        /// <param name="eventLog">The object for saving the event information</param>
        /// <param name="methodBase">The calling method, used for reflection</param>
        /// <param name="Message">Manual Message provided to the method</param>
        /// <param name="ob">Array of objects to set the parameters for on the event log object</param>
        public static void WriteLogEvent(LogManager.EventLevel level, IEventLog eventLog, MethodBase methodBase, string Message, params object[] ob)
        {
            if (CheckLoggingLevel(level))
            {
                // get the method name
                eventLog.MethodName = methodBase.Name.ToString();
                // Get the name of the class that is calling
                eventLog.ClassName = methodBase.Module.ToString();

                SetAttributeValues(eventLog, ob);

                //Set the values on the call object   
                eventLog.Save();
            }
        }

        /// <summary>
        /// Iterates through the object collection and assigns all values that 
        /// have the correct custom attributes
        /// </summary>
        /// <param name="eventLog">The object for saving the event information</param>
        /// <param name="ob">Array of objects to set the parameters for on the event log object</param>
        private static void SetAttributeValues(IEventLog eventLog, object[] ob)
        {
            foreach (object o in ob)
            {
                // Can't use auto mapper because of the serialized properties and labeling
                PropertyInfo[] props = o.GetType().GetProperties();

                foreach (var prop in props)
                {
                    try
                    {
                        var attributes = prop.GetCustomAttributes(false);
                        foreach (var attribute in attributes)
                        {
                            // Find the same named property on the eventLog as the ob and set the value equal
                            if (attribute.GetType() == typeof(ValueLogAttribute))
                            {
                                //I am sure there is a more elegant way to do this                            
                                if (prop.GetType() == eventLog.GetType().GetProperty(prop.Name).GetType())
                                {
                                    PropertyInfo propInfo = eventLog.GetType().GetProperty(prop.Name);
                                    if (propInfo != null)
                                    {
                                        eventLog.GetType().GetProperty(prop.Name).SetValue(eventLog, prop.GetValue(o, null), null);
                                    }
                                }

                            }
                            else if (attribute.GetType() == typeof(SerializeXMLLogAttribute))
                            {
                                //Make sure that there is a property with that name in the eventLog
                                PropertyInfo propInfo = eventLog.GetType().GetProperty(prop.Name);
                                if (propInfo != null)
                                {
                                    //TODO: Serialize the property.  This is assumed because it is a complex type such as a class
                                    eventLog.GetType().GetProperty(prop.Name).SetValue(eventLog, prop.GetValue(o, null), null);

                                    System.IO.StringWriter writer = new System.IO.StringWriter();
                                    
                                    //XmlSerializer serializer = new XmlSerializer(typeof(prop.GetType()));
                                    //serializer.Serialize(writer, prop.GetValue());
                                    

                                }
                                /// Notes:
                                /// XML serialization only serializes public fields and properties. 
                                /// XML serialization does not include any type information. 
                                /// We need to have a default/ non - parameterized constructor in order to serialize an object.
                                /// ReadOnly properties are not serialized.   
                            }
                            else if (attribute.GetType() == typeof(SerializeJSONLogAttribute))
                            {
                                //Make sure that there is a property with that name in the eventLog
                                PropertyInfo propInfo = eventLog.GetType().GetProperty(prop.Name);
                                if (propInfo != null)
                                {
                                    //serialize using JSON
                                    //only store as string with same name
                                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(prop.GetValue(o, null));

                                    eventLog.GetType().GetProperty(prop.Name).SetValue(eventLog, output, null);
                                }
                            }
                        }

                    }
                    catch (Exception exp)
                    {
                        //exp.Message;
                        //throw;
                    }
                }

            }

        }
    }
}

