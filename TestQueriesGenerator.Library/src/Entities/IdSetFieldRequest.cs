//-----------------------------------------------------------------------
// <copyright file="IdSetFieldRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Entities;

using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Services;

public class IdSetFieldRequest : AbstractMetadataFieldRequest, ICompilableRequest
{
    private readonly string value;

    public IdSetFieldRequest(string idName, string metadataField, string metadataValue)
    {
        this.command = "set_field";
        this.targetID = idName;
        this.metadataFieldName = metadataField;
        this.value = metadataValue;

        CompilerService.Assign();
    }

    public string Compile(bool isDebugMode)
    {
        string compiledRequest = this.command + " " + this.metadataFieldName + " " + this.value + " " + this.targetID;

        CompilerService.Trace(compiledRequest);

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
