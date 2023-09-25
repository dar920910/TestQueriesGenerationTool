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

        [XmlAttribute (Metadata.Agency)]
        public bool Agency { get; set; }

        [XmlAttribute (Metadata.Description)]
        public bool Description { get; set; }

        [XmlAttribute (Metadata.Department)]
        public bool Department { get; set; }

        [XmlAttribute (Metadata.Title)]
        public bool Title { get; set; }

        [XmlAttribute (Metadata.Type)]
        public bool Type { get; set; }

        [XmlAttribute (Metadata.UserField1)]
        public bool UserField1 { get; set; }

        [XmlAttribute (Metadata.UserField2)]
        public bool UserField2 { get; set; }

        [XmlAttribute (Metadata.UserField3)]
        public bool UserField3 { get; set; }

        [XmlAttribute (Metadata.UserField4)]
        public bool UserField4 { get; set; }

        [XmlAttribute (Metadata.RecordTime)]
        public bool RecordTime { get; set; }

        [XmlAttribute (Metadata.ModifiedTime)]
        public bool ModifiedTime { get; set; }

        [XmlAttribute (Metadata.KillDate)]
        public bool KillDate { get; set; }

        [XmlAttribute (Metadata.SOM)]
        public bool SOM { get; set; }

        [XmlAttribute (Metadata.DAR)]
        public bool DAR { get; set; }

        [XmlAttribute (Metadata.GOP)]
        public bool GOP { get; set; }

        [XmlAttribute (Metadata.FileSize)]
        public bool FileSize { get; set; }

        [XmlAttribute (Metadata.Resolution)]
        public bool Resolution { get; set; }

        [XmlAttribute (Metadata.VideoFormat)]
        public bool VideoFormat { get; set; }

        [XmlAttribute (Metadata.BitRate)]
        public bool BitRate { get; set; }

        [XmlAttribute (Metadata.Handle)]
        public bool Handle { get; set; }

        [XmlAttribute (Metadata.Link)]
        public bool Link { get; set; }

        [XmlAttribute (Metadata.MachineName)]
        public bool MachineName { get; set; }

        [XmlAttribute (Metadata.UserName)]
        public bool UserName { get; set; }

        [XmlAttribute (Metadata.AudioBits)]
        public bool AudioBits { get; set; }

        [XmlAttribute (Metadata.AudioChannels)]
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
