//-----------------------------------------------------------------------
// <copyright file="ScalableEntity.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Domains;

using System.Xml.Serialization;

/// <summary>
/// Represents an entity which can scale user-defined query units.
/// </summary>
public record ScalableEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScalableEntity"/> class.
    /// </summary>
    public ScalableEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ScalableEntity"/> class.
    /// </summary>
    /// <param name="rtID">Runtime identifier for the entity.</param>
    /// <param name="prefix">Prefix for all IDs within the entity.</param>
    /// <param name="postfixFirst">Postfix number for the first ID within the entity.</param>
    /// <param name="postfixLast">Postfix number for the last ID within the entity.</param>
    public ScalableEntity(string rtID, string prefix, uint postfixFirst, uint postfixLast)
    {
        this.RuntimeID = rtID;
        this.IdNamePrefix = prefix;
        this.FirstScalePostfixNumber = postfixFirst;
        this.LastScalePostfixNumber = postfixLast;
    }

    /// <summary>
    /// Gets entity's config state by default.
    /// </summary>
    /// <returns>The list of entities which support config state by default.</returns>
    public static List<ScalableEntity> ConfigStateByDefault
    {
        get
        {
            return new List<ScalableEntity>()
            {
                new ()
                {
                    RuntimeID = "testGet",
                    IdNamePrefix = "DemoGet",
                    FirstScalePostfixNumber = 0,
                    LastScalePostfixNumber = 9,
                },
                new ()
                {
                    RuntimeID = "testSet",
                    IdNamePrefix = "DemoSet",
                    FirstScalePostfixNumber = 0,
                    LastScalePostfixNumber = 9,
                },
            };
        }
    }

    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    [XmlAttribute("RuntimeID")]
    public string RuntimeID { get; set; }

    /// <summary>
    /// Gets or sets a prefix for names of IDs within the entity.
    /// </summary>
    [XmlAttribute("NamePrefix")]
    public string IdNamePrefix { get; set; }

    /// <summary>
    /// Gets or sets the first postfix number for an ID within the entity.
    /// </summary>
    [XmlAttribute("FirstNumber")]
    public uint FirstScalePostfixNumber { get; set; }

    /// <summary>
    /// Gets or sets the last postfix number for an ID within the entity.
    /// </summary>
    [XmlAttribute("LastNumber")]
    public uint LastScalePostfixNumber { get; set; }
}
