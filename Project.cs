using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace prj2json
{
    //TODO: 
    [XmlRoot(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public class Project
    {
        [XmlElement]
        public List<PropertyGroup> PropertyGroup { set; get; }
    }
}
