using System.Management;

namespace SharpIP.Lib
{
    public static class WMIHelper
    {
        public static T Build<T>(ManagementObject managementObject) 
            where T : new()
        {
            var info = new T();

            var type = typeof(T);
            var properties = type.GetProperties();

            foreach (var p in properties)
            {
                try
                {
                    object value = managementObject[p.Name];
                    p.SetValue(info, value);
                }
                catch { }
            }
            return info;
        }
    }
}
