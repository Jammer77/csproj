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

//        public string Configuration
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }
//        }
//
        //TODO: use path !!
        public string Path => $"{OutputPath}\\{AssemblyName}.{OutputType}";
        public string ProjectName => this.Parent.Name; 

        public SharpProject Parent { set; get; }
    }
}
