//-----------------------------------------------------------------------
// <copyright file="ScaleGetMetaRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Entities;

using TestQueriesGenerator.Library.Domains;

public record ScaleGetMetaRequest : ICompilableRequest
{
    private readonly List<IdFullGetMetadataRequest> getRequests;

    public ScaleGetMetaRequest(List<IdFullGetMetadataRequest> fullGetRequests)
    {
        this.getRequests = fullGetRequests;
    }

    public string Compile(bool isDebugMode)
    {
        string scaleRequest = string.Empty;

        if (isDebugMode)
        {
            foreach (var request in this.getRequests)
            {
                scaleRequest += request.Compile(true);
            }
        }
        else
        {
            foreach (var request in this.getRequests)
            {
                scaleRequest += request.Compile(false);
            }
        }

        return scaleRequest;
    }
}
