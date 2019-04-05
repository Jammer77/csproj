using System;
using Newtonsoft.Json;
namespace Application
{
    public class LaunchTask
    {
        public LaunchTask(){}

        public LaunchTask(string name, string path)
        {
            this.Name = name;
            this.Program = path;
            this.Type = "mono";
            this.Request = "\"request\": \"launch\"";
            this.Cwd = "${workspaceRoot}";
        }

        [JsonProperty("name")]
        public string Name { get; set; } 
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("request")]
        public string Request { get; set; } 
        [JsonProperty("program")]
        public string Program { get; set; } 
        [JsonProperty("cwd")]
        public string Cwd { get; set; }
    }
}
