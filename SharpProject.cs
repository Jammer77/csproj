using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace prj2json
{
    public sealed class SharpProject
    {
        private SharpProject() { }

        private Project _project;
        public static SharpProject FromFile(string filename)
        {
            var result = new SharpProject
            {
                Name = filename
            };

            var serializer = new XmlSerializer(typeof(Project));
            using (var stream = new StreamReader(filename))
            {
                result._project = (Project)serializer.Deserialize(stream);
            }

            foreach (var propertyGroup in result._project.PropertyGroup)
            {
                propertyGroup.Parent = result;
            }

            return result;
        }
        public IEnumerable<PropertyGroup> PropertyGroupCollection => _project.PropertyGroup;

        //public string Name => _project.PropertyGroup.Single(pg => !string.IsNullOrEmpty(pg.AssemblyName))
                                                    //.AssemblyName;

        public IEnumerable<PropertyGroup> DebugPropertyGroupCollection
        {
            get
            {
                return _project.PropertyGroup.Where(pg => pg.DebugSymbols);
            }
        }

        public IEnumerable<PropertyGroup> ReleasePropertyGroupCollection
        {
            get
            {
                return _project.PropertyGroup.Where(pg => !pg.IsGeneral && !pg.DebugSymbols);
            }
        }

        public PropertyGroup GeneralPropertyGroup
        {
            get
            {
                return _project.PropertyGroup.SingleOrDefault(pg => pg.IsGeneral);
            }
        }

        [XmlIgnore]
        public string Name { get; private set; }
    }
}
