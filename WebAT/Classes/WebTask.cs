using Newtonsoft.Json;
using System.Collections.Generic;
using WebAT.Interfaces;

namespace WebAT.Classes
{
    public class WebTask : IWebTask
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore, Required = Required.Always)]
        public int id { get; set; }
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }

        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }

        [JsonProperty(PropertyName = "browser", NullValueHandling = NullValueHandling.Ignore, Required = Required.Always)]
        public string browser { get; set; }

        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore, Required = Required.Always)]
        public string url { get; set; }

        [JsonProperty(PropertyName = "quitBrowserAfter", NullValueHandling = NullValueHandling.Ignore, Required = Required.Always)]
        public bool quitBrowserAfter { get; set; }

        [JsonProperty(PropertyName = "actions", NullValueHandling = NullValueHandling.Ignore, Required = Required.Always)]
        public List<TaskAction> actions { get; set; }
    }
}