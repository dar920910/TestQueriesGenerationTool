//-----------------------------------------------------------------------
// <copyright file="ScaleSetMetaRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Entities;

using TestQueriesGenerator.Library.Domains;

/// <summary>
/// Represents a scalable request to set values of metadata fields.
/// </summary>
public record ScaleSetMetaRequest : ICompilableRequest
{
    private readonly List<IdFullSetMetadataRequest> setRequests;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScaleSetMetaRequest"/> class.
    /// </summary>
    /// <param name="fullSetRequests">The list of requests to set values of all available metadata fields.</param>
    public ScaleSetMetaRequest(List<IdFullSetMetadataRequest> fullSetRequests)
    {
        this.setRequests = fullSetRequests;
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
