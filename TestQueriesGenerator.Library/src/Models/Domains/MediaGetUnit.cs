using System.Xml.Serialization;

namespace TestQueriesGenerator.Library.Models.Domains
{
    public class MediaGetUnit
    {
        [XmlAttribute ("RuntimeID")]
        public string RuntimeID { get; set; }
        public string Name { get; set; }

        public MediaGetUnit() { }
        public MediaGetUnit(string idName)
        {
            Name = idName;
        }

        public MediaGetUnit(string idName, string rtID)
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


        public void Mirror(MediaGetUnit mediaGet)
        {
            this.Agency = mediaGet.Agency;
            this.Department = mediaGet.Department;
            this.Description = mediaGet.Description;
            this.Title = mediaGet.Title;
            this.Type = mediaGet.Type;
            this.UserField1 = mediaGet.UserField1;
            this.UserField2 = mediaGet.UserField2;
            this.UserField3 = mediaGet.UserField3;
            this.UserField4 = mediaGet.UserField4;
            this.RecordTime = mediaGet.RecordTime;
            this.ModifiedTime = mediaGet.ModifiedTime;
            this.KillDate = mediaGet.KillDate;
            this.SOM = mediaGet.SOM;
            this.DAR = mediaGet.DAR;
            this.GOP = mediaGet.GOP;
            this.FileSize = mediaGet.FileSize;
            this.Resolution = mediaGet.Resolution;
            this.VideoFormat = mediaGet.VideoFormat;
            this.BitRate = mediaGet.BitRate;
            this.Handle = mediaGet.Handle;
            this.Link = mediaGet.Link;
            this.MachineName = mediaGet.MachineName;
            this.UserName = mediaGet.UserName;
            this.AudioBits = mediaGet.AudioBits;
            this.AudioChannels = mediaGet.AudioChannels;
        }
    }
}
