using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLURLPOC.Data
{
    public class Builder
    {
        public static JObject ConvertBuilderToJObject(object jobj)
        {
            return (JObject)JToken.FromObject(jobj);
        }
    }
}
