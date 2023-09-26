//-----------------------------------------------------------------------
// <copyright file="IdFullSetMetadataRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Entities;

using TestQueriesGenerator.Library.Domains;

/// <summary>
/// Represents a request to set values of metadata fields.
/// </summary>
public record IdFullSetMetadataRequest : ICompilableRequest
{
    private readonly List<IdSetFieldRequest> setMetadataRequests;

    /// <summary>
    /// Initializes a new instance of the <see cref="IdFullSetMetadataRequest"/> class.
    /// </summary>
    /// <param name="idSetFieldRequests">The list of requests to set a value of a metadata field.</param>
    public IdFullSetMetadataRequest(List<IdSetFieldRequest> idSetFieldRequests)
    {
        this.setMetadataRequests = idSetFieldRequests;
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
