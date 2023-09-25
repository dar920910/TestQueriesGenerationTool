//-----------------------------------------------------------------------
// <copyright file="IdFullGetMetadataRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Entities;

using TestQueriesGenerator.Library.Domains;

public record IdFullGetMetadataRequest : ICompilableRequest
{
    private readonly List<IdGetFieldRequest> getMetadataRequests;

    public IdFullGetMetadataRequest(List<IdGetFieldRequest> idGetFieldRequests)
    {
        this.getMetadataRequests = idGetFieldRequests;
    }

    public string Compile(bool isDebugMode)
    {
        string targetRequest = string.Empty;

        if (isDebugMode)
        {
            foreach (var getRequest in this.getMetadataRequests)
            {
                targetRequest += getRequest.Compile(true) + "\n";
            }
        }
        else
        {
            foreach (var getRequest in this.getMetadataRequests)
            {
                targetRequest += getRequest.Compile(false);
            }
        }

        return targetRequest;
    }
}
