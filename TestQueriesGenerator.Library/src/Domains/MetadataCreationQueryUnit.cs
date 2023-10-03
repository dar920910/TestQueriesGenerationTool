//-----------------------------------------------------------------------
// <copyright file="MetadataCreationQueryUnit.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Domains;

using System.Xml.Serialization;

/// <summary>
/// Represents a user-defined unit to build a metadata creation query.
/// </summary>
public record MetadataCreationQueryUnit
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MetadataCreationQueryUnit"/> class.
    /// </summary>
    public MetadataCreationQueryUnit()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MetadataCreationQueryUnit"/> class.
    /// </summary>
    /// <param name="idName">User-defined name of this query unit object.</param>
    public MetadataCreationQueryUnit(string idName)
    {
        this.Name = idName;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MetadataCreationQueryUnit"/> class.
    /// </summary>
    /// <param name="idName">User-defined name of this query unit object.</param>
    /// <param name="templateUnit">User-defined query unit to mirror values of metadata fields.</param>
    public MetadataCreationQueryUnit(string idName, MetadataCreationQueryUnit templateUnit)
    {
        this.Name = idName;

        this.Agency = templateUnit.Agency;
        this.Department = templateUnit.Department;
        this.Description = templateUnit.Description;
        this.Title = templateUnit.Title;
        this.Type = templateUnit.Type;
        this.UserField1 = templateUnit.UserField1;
        this.UserField2 = templateUnit.UserField2;
        this.UserField3 = templateUnit.UserField3;
        this.UserField4 = templateUnit.UserField4;
    }

    /// <summary>
    /// Gets entity's config state by default.
    /// </summary>
    /// <returns>The list of entities which support config state by default.</returns>
    public static List<MetadataCreationQueryUnit> ConfigStateByDefault
    {
        get
        {
            return new List<MetadataCreationQueryUnit>()
            {
                new ()
                {
                    RuntimeID = "testSet",
                    Agency = "agency",
                    Description = "description",
                    Department = "department",
                    Title = "title",
                    Type = "type",
                    UserField1 = "userfield1",
                    UserField2 = "userfield2",
                    UserField3 = "userfield3",
                    UserField4 = "userfield4",
                },
            };
        }
    }

    /// <summary>
    /// Gets the name of the MetadataCreationQueryUnit object.
    /// </summary>
    /// <value>User-defined name of a unit.</value>
    public string Name { get; }

    /// <summary>
    /// Gets or sets the unique identifier of a query unit (only for deserialization aims).
    /// </summary>
    /// <value>Unique string identifier of this query unit.</value>
    [XmlAttribute("RuntimeID")]
    public string RuntimeID { get; set; }

    /// <summary>
    /// Gets or sets a value of the 'Agency' metadata field for this query unit.
    /// </summary>
    [XmlElement(Metadata.Agency)]
    public string Agency { get; set; }

    /// <summary>
    /// Gets or sets a value of the 'Description' metadata field for this query unit.
    /// </summary>
    [XmlElement(Metadata.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets a value of the 'Department' metadata field for this query unit.
    /// </summary>
    [XmlElement(Metadata.Department)]
    public string Department { get; set; }

    /// <summary>
    /// Gets or sets a value of the 'Title' metadata field for this query unit.
    /// </summary>
    [XmlElement(Metadata.Title)]
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets a value of the 'Type' metadata field for this query unit.
    /// </summary>
    [XmlElement(Metadata.Type)]
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets a value of the 'UserField1' metadata field for this query unit.
    /// </summary>
    [XmlElement(Metadata.UserField1)]
    public string UserField1 { get; set; }

    /// <summary>
    /// Gets or sets a value of the 'UserField2' metadata field for this query unit.
    /// </summary>
    [XmlElement(Metadata.UserField2)]
    public string UserField2 { get; set; }

    /// <summary>
    /// Gets or sets a value of the 'UserField3' metadata field for this query unit.
    /// </summary>
    [XmlElement(Metadata.UserField3)]
    public string UserField3 { get; set; }

    /// <summary>
    /// Gets or sets a value of the 'UserField4' metadata field for this query unit.
    /// </summary>
    [XmlElement(Metadata.UserField4)]
    public string UserField4 { get; set; }
}
