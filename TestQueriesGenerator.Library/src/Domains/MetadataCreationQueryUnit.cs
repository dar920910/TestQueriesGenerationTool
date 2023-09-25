using System.Xml.Serialization;

namespace TestQueriesGenerator.Library.Domains
{
    public class MetadataCreationQueryUnit
    {
        [XmlAttribute ("RuntimeID")]
        public string RuntimeID { get; set; }
        public string Name { get; }

        public MetadataCreationQueryUnit() { }
        public MetadataCreationQueryUnit(string idName)
        {
            Name = idName;
        }
        public MetadataCreationQueryUnit(string idName, string rtID)
        {
            Name = idName;
            RuntimeID = rtID;
        }

        [XmlElement (Metadata.Agency)]
        public string Agency { get; set; }

        [XmlElement (Metadata.Description)]
        public string Description { get; set; }

        [XmlElement (Metadata.Department)]
        public string Department { get; set; }

        [XmlElement (Metadata.Title)]
        public string Title { get; set; }

        [XmlElement (Metadata.Type)]
        public string Type { get; set; }

        [XmlElement (Metadata.UserField1)]
        public string UserField1 { get; set; }

        [XmlElement (Metadata.UserField2)]
        public string UserField2 { get; set; }

        [XmlElement (Metadata.UserField3)]
        public string UserField3 { get; set; }

        [XmlElement (Metadata.UserField4)]
        public string UserField4 { get; set; }

        public void Mirror(MetadataCreationQueryUnit unit)
        {
            Agency = unit.Agency;
            Department = unit.Department;
            Description = unit.Description;
            Title = unit.Title;
            Type = unit.Type;
            UserField1 = unit.UserField1;
            UserField2 = unit.UserField2;
            UserField3 = unit.UserField3;
            UserField4 = unit.UserField4;
        }
    }
}
