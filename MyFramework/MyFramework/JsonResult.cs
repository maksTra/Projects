using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonResult
    {
        [JsonProperty("HighlightFields")]
        public List<Fields> HighlightFields { get; set; }
        [JsonProperty("Fields")]
        public List<Fields> Fields { get; set; }
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Score")]
        public double Score { get; set; }
    }

    public class Fields
    {
        [JsonProperty("FieldName")]
        public string FieldName { get; set; }
        [JsonProperty("FieldType")]
        public string FieldType { get; set; }
        [JsonProperty("FieldValue")]
        public Object FieldValue { get; set; }
    }
}
