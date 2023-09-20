using System.Xml.Serialization;

namespace TestQueriesGenerator.Library.Domains
{
    public class ScalableEntity
    {
        [XmlAttribute ("RuntimeID")]
        public string RuntimeID { get; set; }

        [XmlAttribute ("NamePrefix")]
        public string IdNamePrefix { get; set; }

        [XmlAttribute ("FirstNumber")]
        public uint FirstScalePostfixNumber { get; set; }

        [XmlAttribute ("LastNumber")]
        public uint LastScalePostfixNumber { get; set; }
        public ScalableEntity() { }

        public ScalableEntity(string rtID, string prefix, uint postfixFirst, uint postfixLast)
        {
            RuntimeID = rtID;
            IdNamePrefix = prefix;
            FirstScalePostfixNumber = postfixFirst;
            LastScalePostfixNumber = postfixLast;
        }
    }
}
