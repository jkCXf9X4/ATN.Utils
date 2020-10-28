using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Misc.Data.IO
{
    public static class Json
    {
        public static T Deserialize<T>(string json)
        {
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }

        public static string Serialize(object json, bool ignoreNulls = true)
        {
            var nullHandling = ignoreNulls ? NullValueHandling.Ignore : NullValueHandling.Include;

            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.None,
                NullValueHandling = nullHandling
            };

            string str = JsonConvert.SerializeObject(json, settings);
            return str;
        }
    }
}
