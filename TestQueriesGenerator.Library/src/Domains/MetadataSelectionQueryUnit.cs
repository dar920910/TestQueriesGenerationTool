using System.Xml.Serialization;

namespace TestQueriesGenerator.Library.Domains
{
    public class MetadataSelectionQueryUnit
    {
        [XmlAttribute ("RuntimeID")]
        public string RuntimeID { get; set; }
        public string Name { get; set; }

        public MetadataSelectionQueryUnit() { }
        public MetadataSelectionQueryUnit(string idName)
        {
            Name = idName;
        }
        public MetadataSelectionQueryUnit(string idName, string rtID)
        {
            Name = idName;
            RuntimeID = rtID;
        }

        [XmlAttribute (MetaAttribute.Agency)]
        public bool Agency { get; set; }

        [XmlAttribute (MetaAttribute.Description)]
        public bool Description { get; set; }

        [XmlAttribute (MetaAttribute.Department)]
        public bool Department { get; set; }

        [XmlAttribute (MetaAttribute.Title)]
        public bool Title { get; set; }

        [XmlAttribute (MetaAttribute.Type)]
        public bool Type { get; set; }

        [XmlAttribute (MetaAttribute.UserField1)]
        public bool UserField1 { get; set; }

        [XmlAttribute (MetaAttribute.UserField2)]
        public bool UserField2 { get; set; }

        [XmlAttribute (MetaAttribute.UserField3)]
        public bool UserField3 { get; set; }

        [XmlAttribute (MetaAttribute.UserField4)]
        public bool UserField4 { get; set; }

        [XmlAttribute (MetaAttribute.RecordTime)]
        public bool RecordTime { get; set; }

        [XmlAttribute (MetaAttribute.ModifiedTime)]
        public bool ModifiedTime { get; set; }

        [XmlAttribute (MetaAttribute.KillDate)]
        public bool KillDate { get; set; }

        [XmlAttribute (MetaAttribute.SOM)]
        public bool SOM { get; set; }

        [XmlAttribute (MetaAttribute.DAR)]
        public bool DAR { get; set; }

        [XmlAttribute (MetaAttribute.GOP)]
        public bool GOP { get; set; }

        [XmlAttribute (MetaAttribute.FileSize)]
        public bool FileSize { get; set; }

        [XmlAttribute (MetaAttribute.Resolution)]
        public bool Resolution { get; set; }

        [XmlAttribute (MetaAttribute.VideoFormat)]
        public bool VideoFormat { get; set; }

        [XmlAttribute (MetaAttribute.BitRate)]
        public bool BitRate { get; set; }

        [XmlAttribute (MetaAttribute.Handle)]
        public bool Handle { get; set; }

        [XmlAttribute (MetaAttribute.Link)]
        public bool Link { get; set; }

        [XmlAttribute (MetaAttribute.MachineName)]
        public bool MachineName { get; set; }

        [XmlAttribute (MetaAttribute.UserName)]
        public bool UserName { get; set; }

        [XmlAttribute (MetaAttribute.AudioBits)]
        public bool AudioBits { get; set; }

        [XmlAttribute (MetaAttribute.AudioChannels)]
        public bool AudioChannels { get; set; }


        public void Mirror(MetadataSelectionQueryUnit unit)
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
            RecordTime = unit.RecordTime;
            ModifiedTime = unit.ModifiedTime;
            KillDate = unit.KillDate;
            SOM = unit.SOM;
            DAR = unit.DAR;
            GOP = unit.GOP;
            FileSize = unit.FileSize;
            Resolution = unit.Resolution;
            VideoFormat = unit.VideoFormat;
            BitRate = unit.BitRate;
            Handle = unit.Handle;
            Link = unit.Link;
            MachineName = unit.MachineName;
            UserName = unit.UserName;
            AudioBits = unit.AudioBits;
            AudioChannels = unit.AudioChannels;
        }
    }
}
