using Newtonsoft.Json;
using WebAT.Interfaces;
using static System.String;

namespace WebAT.Classes {
    // A container class to store browser actions on Json file
    public class TaskAction : ITaskAction {       
        [JsonProperty(PropertyName = "action", NullValueHandling = NullValueHandling.Ignore, Required = Required.Always)]
        public string action { get; set; } = Empty;
        [JsonProperty(PropertyName = "findBy", NullValueHandling = NullValueHandling.Ignore)]
        public string findBy { get; set; } = Empty;
        [JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
        public string value { get; set; } = Empty;
        [JsonProperty(PropertyName = "keys", NullValueHandling = NullValueHandling.Ignore)]
        public string keys { get; set; } = Empty;
    }
}