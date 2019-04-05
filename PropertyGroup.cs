using System;
using System.Xml.Serialization;

namespace prj2json
{
    public class PropertyGroup
    {
        private string outputType;
        private string assemblyName;

        //https://docs.microsoft.com/ru-ru/visualstudio/msbuild/common-msbuild-project-properties?view=vs-2019
        public bool IsGeneral => !string.IsNullOrEmpty(assemblyName) &&
                                 !string.IsNullOrEmpty(outputType);

        [XmlAttribute]
        public string Condition { get; set; }
        [XmlElement]
        public string AssemblyName
        {
            get =>
                !this.IsGeneral && string.IsNullOrEmpty(assemblyName)
                    ? this.Parent.GeneralPropertyGroup.AssemblyName
                    : assemblyName;
            set => assemblyName = value;
        }
        
        [XmlElement]
        public string OutputType
        {
            get
            {
                var result = !this.IsGeneral && string.IsNullOrEmpty(outputType)
                    ? this.Parent?.GeneralPropertyGroup.OutputType
                    : outputType;

                return result;
            }
            set => outputType = value;
        }

        [XmlElement]
        public bool DebugSymbols { get; set; }
        [XmlElement]
        public string OutputPath { get; set; }

        //TODO: use path !!
        public string Path => System.IO.Path.Combine(OutputPath.Replace('\\', System.IO.Path.DirectorySeparatorChar ), $"{AssemblyName}{GetExtension(OutputType)}");
       
        private string GetExtension(string type)
        {
            string result;
            switch (type)
            {
                case "Exe":
                    result = ".exe";
                    break;
                    //TODO add another cases
                default:
                    result = "";
                    break;
            }
            return result;
        }
        public string ProjectName => this.Parent.Name; 

        public SharpProject Parent { set; get; }
        public string Configuration 
        { 
            get
            {
                string configuration = "DEBUG";
                return configuration;
            }
        }
    }
}
