//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#define TESTING
#undef TESTING

using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Entities;
using TestQueriesGenerator.Library.Services;
using static System.Console;

#if TESTING
TestConfiguration();
TestDeserialization();
TestRequests();
#else
CompilerService.Run();
#endif

void TestConfiguration()
{
    WriteLine("{0}: {1}", nameof(CompilerService.ScaleRequestConfigPath), CompilerService.ScaleRequestConfigPath);
    WriteLine("{0}: {1}", nameof(CompilerService.RequestGetTypeConfigPath), CompilerService.RequestGetTypeConfigPath);
    WriteLine("{0}: {1}", nameof(CompilerService.RequestSetTypeConfigPath), CompilerService.RequestSetTypeConfigPath);
}

void TestRequests()
{
    var scale = new ScalableEntity("test", "ScalableTest", 0, 1000);

    List<MetadataSelectionQueryUnit> metadataGetUnits = CompilerService.CreateGetUnitsList(scale);
    List<MetadataCreationQueryUnit> metadataSetUnits = CompilerService.CreateSetUnitsList(scale);

    ScaleGetMetaRequest scaleGetRequest = CompilerService.CreateScaleGetRequest(metadataGetUnits);
    ScaleSetMetaRequest scaleSetRequest = CompilerService.CreateScaleSetRequest(metadataSetUnits);

    string scaleGetRequestString = scaleGetRequest.Compile(true);
    string scaleSetRequestString = scaleSetRequest.Compile(true);

    OutputConsoleDevice.OutCompiledRequest(scaleGetRequestString);
    OutputConsoleDevice.OutCompiledRequest(scaleSetRequestString);

    CompilerService.WriteSingleCompiledRequestToTargetFile(scaleGetRequestString, "resultsGet.txt");
    CompilerService.WriteSingleCompiledRequestToTargetFile(scaleSetRequestString, "resultsSet.txt");
}
