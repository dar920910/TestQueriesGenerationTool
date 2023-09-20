#define TESTING
#undef TESTING

using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Entities;
using static TestQueriesGenerator.Library.Services.CompiledOutputService;
using static TestQueriesGenerator.Library.Services.ConfigService;
using static TestQueriesGenerator.Library.Services.DeserializationService;
using static TestQueriesGenerator.Library.Services.RequestService;
using static System.Console;


#if TESTING
TestConfiguration();
TestDeserialization();
TestRequests();
#else
TestQueriesGenerator.Library.Services.CompilerService.Run();
#endif


void TestConfiguration()
{
    WriteLine("{0}: {1}", nameof(ScaleRequestConfigPath), ScaleRequestConfigPath);
    WriteLine("{0}: {1}", nameof(RequestGetTypeConfigPath), RequestGetTypeConfigPath);
    WriteLine("{0}: {1}", nameof(RequestSetTypeConfigPath), RequestSetTypeConfigPath);
}

void TestDeserialization()
{
    List<ScalableEntity> scales = DeserializeScalableEntities();
    List<MetadataSelectionQueryUnit> getUnits = DeserializeMetadataSelectionQueryUnits();
    List<MetadataCreationQueryUnit> setUnits = DeserializeMetadataCreationQueryUnits();

    Dictionary<MetadataSelectionQueryUnit, ScalableEntity> metadataGetScales = CombineMetadataSelectionQueryScales(getUnits, scales);
    Dictionary<MetadataCreationQueryUnit, ScalableEntity> metadataSetScales = CombineMetadataCreationQueryScales(setUnits, scales);

    OutGetScales(metadataGetScales);
    OutSetScales(metadataSetScales);
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

    OutToConsole(scaleGetRequestString);
    OutToConsole(scaleSetRequestString);

    OutToFile(scaleGetRequestString, "resultsGet.txt");
    OutToFile(scaleSetRequestString, "resultsSet.txt");
}
