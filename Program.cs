using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Application;
using Newtonsoft.Json;

namespace prj2json
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var projFile = "prj2json.csproj";
            var project = SharpProject.FromFile(projFile);
            //string name = project.Name;
            IEnumerable<PropertyGroup> debugGroups = project.DebugPropertyGroupCollection;
            IEnumerable<PropertyGroup> releaseGroups = project.ReleasePropertyGroupCollection;

            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(new LaunchTask());
            string json = JsonConvert.SerializeObject(new LaunchTask());
        }
    }
}
