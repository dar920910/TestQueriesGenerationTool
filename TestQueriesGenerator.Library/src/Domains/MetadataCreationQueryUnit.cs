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

        [XmlElement (MetaAttribute.Agency)]
        public string Agency { get; set; }

        [XmlElement (MetaAttribute.Description)]
        public string Description { get; set; }

        [XmlElement (MetaAttribute.Department)]
        public string Department { get; set; }

        [XmlElement (MetaAttribute.Title)]
        public string Title { get; set; }

        [XmlElement (MetaAttribute.Type)]
        public string Type { get; set; }

        [XmlElement (MetaAttribute.UserField1)]
        public string UserField1 { get; set; }

        [XmlElement (MetaAttribute.UserField2)]
        public string UserField2 { get; set; }

        [XmlElement (MetaAttribute.UserField3)]
        public string UserField3 { get; set; }

        [XmlElement (MetaAttribute.UserField4)]
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
