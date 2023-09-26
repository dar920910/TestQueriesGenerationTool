//-----------------------------------------------------------------------
// <copyright file="IdFullGetMetadataRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Entities;

using TestQueriesGenerator.Library.Domains;

/// <summary>
/// Represents a request to get values of metadata fields.
/// </summary>
public record IdFullGetMetadataRequest : ICompilableRequest
{
    private readonly List<IdGetFieldRequest> getMetadataRequests;

    /// <summary>
    /// Initializes a new instance of the <see cref="IdFullGetMetadataRequest"/> class.
    /// </summary>
    /// <param name="idGetFieldRequests">The list of requests to get a value of a metadata field.</param>
    public IdFullGetMetadataRequest(List<IdGetFieldRequest> idGetFieldRequests)
    {
        this.getMetadataRequests = idGetFieldRequests;
    }

    /// <summary>
    /// Execute request compilation.
    /// </summary>
    /// <param name="isDebugMode">If 'true' then the debug mode is enabled else disabled.</param>
    /// <returns>Compiled request string.</returns>
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
