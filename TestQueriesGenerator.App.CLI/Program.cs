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
using static TestQueriesGenerator.Library.Services.RequestService;

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

    List<MetadataSelectionQueryUnit> metadataGetUnits = CreateGetUnitsList(scale);
    List<MetadataCreationQueryUnit> metadataSetUnits = CreateSetUnitsList(scale);

    ScaleGetMetaRequest scaleGetRequest = CreateScaleGetRequest(metadataGetUnits);
    ScaleSetMetaRequest scaleSetRequest = CreateScaleSetRequest(metadataSetUnits);

    string scaleGetRequestString = scaleGetRequest.Compile(true);
    string scaleSetRequestString = scaleSetRequest.Compile(true);

    CompilerService.OutToConsole(scaleGetRequestString);
    CompilerService.OutToConsole(scaleSetRequestString);

    CompilerService.OutToFile(scaleGetRequestString, "resultsGet.txt");
    CompilerService.OutToFile(scaleSetRequestString, "resultsSet.txt");
}
