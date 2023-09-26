//-----------------------------------------------------------------------
// <copyright file="ScaleGetMetaRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Entities;

using TestQueriesGenerator.Library.Domains;

/// <summary>
/// Represents a scalable request to get values of metadata fields.
/// </summary>
public record ScaleGetMetaRequest : ICompilableRequest
{
    private readonly List<IdFullGetMetadataRequest> getRequests;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScaleGetMetaRequest"/> class.
    /// </summary>
    /// <param name="fullGetRequests">The list of requests to get values of all available metadata fields.</param>
    public ScaleGetMetaRequest(List<IdFullGetMetadataRequest> fullGetRequests)
    {
        this.getRequests = fullGetRequests;
    }

    /// <summary>
    /// Execute request compilation.
    /// </summary>
    /// <param name="isDebugMode">If 'true' then the debug mode is enabled else disabled.</param>
    /// <returns>Compiled request string.</returns>
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
