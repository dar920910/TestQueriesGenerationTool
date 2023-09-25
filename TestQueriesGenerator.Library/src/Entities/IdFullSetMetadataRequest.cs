//-----------------------------------------------------------------------
// <copyright file="IdFullSetMetadataRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Entities;

using TestQueriesGenerator.Library.Domains;

public class IdFullSetMetadataRequest : ICompilableRequest
{
    private readonly List<IdSetFieldRequest> setMetadataRequests;

    public IdFullSetMetadataRequest(List<IdSetFieldRequest> idSetFieldRequests)
    {
        this.setMetadataRequests = idSetFieldRequests;
    }

    public string Compile(bool isDebugMode)
    {
        string targetRequest = string.Empty;

        if (isDebugMode)
        {
            foreach (var setRequest in this.setMetadataRequests)
            {
                targetRequest += setRequest.Compile(true) + "\n";
            }
        }
        else
        {
            foreach (var setRequest in this.setMetadataRequests)
            {
                targetRequest += setRequest.Compile(false);
            }
        }

        return targetRequest;
    }
}
