//-----------------------------------------------------------------------
// <copyright file="MetadataSelectionQueryUnit.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Domains;

using System.Xml.Serialization;

/// <summary>
/// Represents a user-defined unit to build a metadata selection query.
/// </summary>
public record MetadataSelectionQueryUnit
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MetadataSelectionQueryUnit"/> class.
    /// </summary>
    public MetadataSelectionQueryUnit()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MetadataSelectionQueryUnit"/> class.
    /// </summary>
    /// <param name="idName">User-defined name of this query unit.</param>
    public MetadataSelectionQueryUnit(string idName)
    {
        this.Name = idName;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MetadataSelectionQueryUnit"/> class.
    /// </summary>
    /// <param name="idName">User-defined name of this query unit.</param>
    /// <param name="templateUnit">User-defined query unit to mirror values of metadata fields.</param>
    public MetadataSelectionQueryUnit(string idName, MetadataSelectionQueryUnit templateUnit)
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
        this.RecordTime = templateUnit.RecordTime;
        this.ModifiedTime = templateUnit.ModifiedTime;
        this.KillDate = templateUnit.KillDate;
        this.SOM = templateUnit.SOM;
        this.DAR = templateUnit.DAR;
        this.GOP = templateUnit.GOP;
        this.FileSize = templateUnit.FileSize;
        this.Resolution = templateUnit.Resolution;
        this.VideoFormat = templateUnit.VideoFormat;
        this.BitRate = templateUnit.BitRate;
        this.Handle = templateUnit.Handle;
        this.Link = templateUnit.Link;
        this.MachineName = templateUnit.MachineName;
        this.UserName = templateUnit.UserName;
        this.AudioBits = templateUnit.AudioBits;
        this.AudioChannels = templateUnit.AudioChannels;
    }

    /// <summary>
    /// Gets the name of the MetadataSelectionQueryUnit object.
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
    /// Gets or sets a value indicating whether of the 'Agency' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.Agency)]
    public bool Agency { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'Description' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.Description)]
    public bool Description { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'Department' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.Department)]
    public bool Department { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'Title' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.Title)]
    public bool Title { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'Type' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.Type)]
    public bool Type { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'UserField1' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.UserField1)]
    public bool UserField1 { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'UserField2' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.UserField2)]
    public bool UserField2 { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'UserField3' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.UserField3)]
    public bool UserField3 { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'UserField4' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.UserField4)]
    public bool UserField4 { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'RecordTime' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.RecordTime)]
    public bool RecordTime { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'ModifiedTime' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.ModifiedTime)]
    public bool ModifiedTime { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'KillDate' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.KillDate)]
    public bool KillDate { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'SOM' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.SOM)]
    public bool SOM { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'DAR' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.DAR)]
    public bool DAR { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'GOP' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.GOP)]
    public bool GOP { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'FileSize' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.FileSize)]
    public bool FileSize { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'Resolution' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.Resolution)]
    public bool Resolution { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'VideoFormat' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.VideoFormat)]
    public bool VideoFormat { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'BitRate' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.BitRate)]
    public bool BitRate { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'Handle' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.Handle)]
    public bool Handle { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'Link' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.Link)]
    public bool Link { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'MachineName' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.MachineName)]
    public bool MachineName { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'UserName' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.UserName)]
    public bool UserName { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'AudioBits' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.AudioBits)]
    public bool AudioBits { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the 'AudioChannels' metadata field to be enabled to request.
    /// </summary>
    /// <value>Enabled when is 'true' else disabled.</value>
    [XmlAttribute(Metadata.AudioChannels)]
    public bool AudioChannels { get; set; }
}
