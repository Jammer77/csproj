using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var projFile = args.FirstOrDefault();
            if(string.IsNullOrEmpty(projFile))
            {
                //TODO: show command line options
                Console.WriteLine("Using: prj2json <csprojectname.csproj>");
                return;
            }
            var project = SharpProject.FromFile(projFile);
            IEnumerable<PropertyGroup> debugGroups = project.DebugPropertyGroupCollection;
            IEnumerable<PropertyGroup> releaseGroups = project.ReleasePropertyGroupCollection;

            foreach (var group in debugGroups)
            {
                var buildCommand = BashHelper.CreateBuildCommand(group.ProjectName, group.Configuration);
                var runCommand = BashHelper.CreateRunCommand(group.Path);
                Debug.WriteLine(buildCommand);
                Debug.WriteLine(runCommand);
            }

            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(new LaunchTask());
            string json = JsonConvert.SerializeObject(new LaunchTask());
        }
    }
}
