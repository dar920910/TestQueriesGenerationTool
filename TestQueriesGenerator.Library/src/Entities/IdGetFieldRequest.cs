//-----------------------------------------------------------------------
// <copyright file="IdGetFieldRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Entities;

using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Services;

public class IdGetFieldRequest : AbstractMetadataFieldRequest, ICompilableRequest
{
    public IdGetFieldRequest(string idName, string metadataField)
    {
        this.command = "get_field";
        this.targetID = idName;
        this.metadataFieldName = metadataField;

        CompilerService.Assign();
    }

    public string Compile(bool isDebugMode)
    {
        string compiledRequest = this.command + " " + this.metadataFieldName + " " + this.targetID;

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
