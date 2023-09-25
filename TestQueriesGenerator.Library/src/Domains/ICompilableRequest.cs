//-----------------------------------------------------------------------
// <copyright file="ICompilableRequest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Domains;

public interface ICompilableRequest
{
    public string Compile(bool isDebugMode);
}
