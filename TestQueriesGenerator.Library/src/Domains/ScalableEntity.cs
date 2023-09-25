//-----------------------------------------------------------------------
// <copyright file="ScalableEntity.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Domains;

using System.Xml.Serialization;

public record ScalableEntity
{
    public ScalableEntity()
    {
    }

    public ScalableEntity(string rtID, string prefix, uint postfixFirst, uint postfixLast)
    {
        this.RuntimeID = rtID;
        this.IdNamePrefix = prefix;
        this.FirstScalePostfixNumber = postfixFirst;
        this.LastScalePostfixNumber = postfixLast;
    }

    [XmlAttribute("RuntimeID")]
    public string RuntimeID { get; set; }

    [XmlAttribute("NamePrefix")]
    public string IdNamePrefix { get; set; }

    [XmlAttribute("FirstNumber")]
    public uint FirstScalePostfixNumber { get; set; }

    [XmlAttribute("LastNumber")]
    public uint LastScalePostfixNumber { get; set; }
}
