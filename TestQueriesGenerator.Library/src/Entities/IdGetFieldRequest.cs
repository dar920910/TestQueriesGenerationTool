//-----------------------------------------------------------------------
// <copyright file="IdGetFieldRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Entities;

using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Services;

/// <summary>
/// Represents a request to get a metadata field value.
/// </summary>
public class IdGetFieldRequest : AbstractMetadataFieldRequest, ICompilableRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IdGetFieldRequest"/> class.
    /// </summary>
    /// <param name="idName">Requested unit's name.</param>
    /// <param name="metadataField">Metadata field name.</param>
    public IdGetFieldRequest(string idName, string metadataField)
    {
        this.command = "get_field";
        this.targetID = idName;
        this.metadataFieldName = metadataField;
    }

    /// <summary>
    /// Execute request compilation.
    /// </summary>
    /// <param name="isDebugMode">If 'true' then the debug mode is enabled else disabled.</param>
    /// <returns>Compiled request string.</returns>
    public string Compile(bool isDebugMode)
    {
        string compiledRequest = this.command + " " + this.metadataFieldName + " " + this.targetID;

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
