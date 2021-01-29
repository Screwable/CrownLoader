using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using System.Reflection;
using CrownClient.PhotonUtils;
using SysCollections = System.Collections.Generic;
using CrownLoader;

namespace CrownClient.Utils
{
    public static class Il2CppExtensions
    {
        //Convert IL2cpp dictionary to readable system dictionary
        public static SysCollections.List<SysCollections.KeyValuePair<string, string>> ConvertToDictionary(this Dictionary<byte, Object> dictionary)
        {
            SysCollections.List<SysCollections.KeyValuePair<string, string>> result = new SysCollections.List<SysCollections.KeyValuePair<string, string>>();
            foreach(KeyValuePair<byte, Object> kvp in dictionary)
            {
                //Parse byte code to actual name
                string paramKey = ParseCode(kvp.Key, typeof(ParameterKey));
                string paramValue = $"({kvp.Value.GetSystemType()}){kvp.Value.GetValue()}";
                result.Add(new SysCollections.KeyValuePair<string, string>(paramKey, paramValue));
            }
            return result;
        }

        //Get the value of the object as a string, remove any excess letters after 30 (mainly bc the secretKey is like 2000 chars long)
        public static string GetValue(this Object @object)
        {
            string result = @object.ToString();
            if (result.Length > 30)
                result = result.Substring(0, 30);

            return result;
        }

        //Get the standard system type that this object is
        public static string GetSystemType(this Object @object)
        {
            return @object.GetIl2CppType().ToString().Replace("System.", "");
        }

        public static string ParseCode(byte code, System.Type type)
        {
            string result = System.Enum.GetName(type, code);
            return !string.IsNullOrEmpty(result) ? result : code.ToString();
        }
    }
}
