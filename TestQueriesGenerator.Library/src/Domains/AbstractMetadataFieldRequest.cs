//-----------------------------------------------------------------------
// <copyright file="AbstractMetadataFieldRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Domains;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Represents an abstract request for a metadata field.
/// </summary>
[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
public abstract class AbstractMetadataFieldRequest
{
    /// <summary>
    /// Metadata field name.
    /// </summary>
    protected string metadataFieldName;

    /// <summary>
    /// Command of a request.
    /// </summary>
    protected string command;

    /// <summary>
    /// Identifier of a target entity.
    /// </summary>
    protected string targetID;
}
