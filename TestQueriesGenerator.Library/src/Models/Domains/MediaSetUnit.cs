using System.Xml.Serialization;

namespace TestQueriesGenerator.Library.Models.Domains
{
    public class MediaSetUnit
    {
        [XmlAttribute ("RuntimeID")]
        public string RuntimeID { get; set; }
        public string Name { get; }

        public MediaSetUnit() { }
        public MediaSetUnit(string idName)
        {
            Name = idName;
        }
        public MediaSetUnit(string idName, string rtID)
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

        public void Mirror(MediaSetUnit mediaSet)
        {
            this.Agency = mediaSet.Agency;
            this.Department = mediaSet.Department;
            this.Description = mediaSet.Description;
            this.Title = mediaSet.Title;
            this.Type = mediaSet.Type;
            this.UserField1 = mediaSet.UserField1;
            this.UserField2 = mediaSet.UserField2;
            this.UserField3 = mediaSet.UserField3;
            this.UserField4 = mediaSet.UserField4;
        }
    }
}
