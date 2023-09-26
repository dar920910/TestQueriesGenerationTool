//-----------------------------------------------------------------------
// <copyright file="ICompilableRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Domains;

/// <summary>
/// Declares a contract for entities which support request compilation.
/// </summary>
public interface ICompilableRequest
{
    /// <summary>
    /// Execute request compilation.
    /// </summary>
    /// <param name="isDebugMode">If 'true' then the debug mode is enabled else disabled.</param>
    /// <returns>Compiled request string.</returns>
    public string Compile(bool isDebugMode);
}
