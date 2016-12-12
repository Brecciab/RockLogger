using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockLogger
{
    /// <summary>
    /// Used to create a way to add custom attributes to a field.
    /// By adding the decorations the fields will be either logged by value
    /// to a matching parameter in the save or serialized and stored in 
    /// SerializedData parameter
    /// 
    /// </summary>
    /// 



    /// <summary>
    /// Currently only supports string, int, int32, bool and 
    /// </summary>
    public class ValueLogAttribute : Attribute { };

    public class SerializeXMLLogAttribute : Attribute { };

    public class SerializeJSONLogAttribute : Attribute { };
    
}
