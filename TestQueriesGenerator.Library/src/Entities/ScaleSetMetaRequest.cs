//-----------------------------------------------------------------------
// <copyright file="ScaleSetMetaRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Entities;

using TestQueriesGenerator.Library.Domains;

public record ScaleSetMetaRequest : ICompilableRequest
{
    private readonly List<IdFullSetMetadataRequest> setRequests;

    public ScaleSetMetaRequest(List<IdFullSetMetadataRequest> fullSetRequests)
    {
        this.setRequests = fullSetRequests;
    }

    public string Compile(bool isDebugMode)
    {
        string scaleRequest = string.Empty;

        if (isDebugMode)
        {
            foreach (var request in this.setRequests)
            {
                scaleRequest += request.Compile(true);
            }
        }
        else
        {
            foreach (var request in this.setRequests)
            {
                scaleRequest += request.Compile(false);
            }
        }

        return scaleRequest;
    }
}
