//-----------------------------------------------------------------------
// <copyright file="IdSetFieldRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Entities;

using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Services;

/// <summary>
/// Represents a request to set a metadata field value.
/// </summary>
public class IdSetFieldRequest : AbstractMetadataFieldRequest, ICompilableRequest
{
    private readonly string value;

    /// <summary>
    /// Initializes a new instance of the <see cref="IdSetFieldRequest"/> class.
    /// </summary>
    /// <param name="idName">Requested unit's name.</param>
    /// <param name="metadataField">Metadata field name.</param>
    /// <param name="metadataValue">Metadata field value.</param>
    public IdSetFieldRequest(string idName, string metadataField, string metadataValue)
    {
        this.command = "set_field";
        this.targetID = idName;
        this.metadataFieldName = metadataField;
        this.value = metadataValue;
    }

    /// <summary>
    /// Execute request compilation.
    /// </summary>
    /// <param name="isDebugMode">If 'true' then the debug mode is enabled else disabled.</param>
    /// <returns>Compiled request string.</returns>
    public string Compile(bool isDebugMode)
    {
        string compiledRequest = this.command + " " + this.metadataFieldName + " " + this.value + " " + this.targetID;

        CompilerService.Register(compiledRequest);

        if (isDebugMode)
        {
            return compiledRequest;
        }
        else
        {
            return compiledRequest += "&";
        }
    }
}
