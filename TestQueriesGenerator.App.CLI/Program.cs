#define TESTING
#undef TESTING

using TestQueriesGenerator.Library.Models.Domains;
using TestQueriesGenerator.Library.Models.Entities;
using static TestQueriesGenerator.Library.Models.Services.CompiledOutputService;
using static TestQueriesGenerator.Library.Models.Services.ConfigService;
using static TestQueriesGenerator.Library.Models.Services.DeserializationService;
using static TestQueriesGenerator.Library.Models.Services.RequestService;
using static System.Console;


#if TESTING
TestConfiguration();
TestDeserialization();
TestRequests();
#else
TestQueriesGenerator.Library.Models.Services.CompilerService.Run();
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
    List<MediaGetUnit> getUnits = DeserializeMediaGetUnits();
    List<MediaSetUnit> setUnits = DeserializeMediaSetUnits();

    Dictionary<MediaGetUnit, ScalableEntity> mediaGetScales = CombineMediaGetScales(getUnits, scales);
    Dictionary<MediaSetUnit, ScalableEntity> mediaSetScales = CombineMediaSetScales(setUnits, scales);

    OutGetScales(mediaGetScales);
    OutSetScales(mediaSetScales);
}

void TestRequests()
{
    var scale = new ScalableEntity("test", "ScalableTest", 0, 1000);

    List<MediaGetUnit> mediaGetUnits = CreateGetUnitsList(scale);
    List<MediaSetUnit> mediaSetUnits = CreateSetUnitsList(scale);

    ScaleGetMetaRequest scaleGetRequest = CreateScaleGetRequest(mediaGetUnits);
    ScaleSetMetaRequest scaleSetRequest = CreateScaleSetRequest(mediaSetUnits);

    string scaleGetRequestString = scaleGetRequest.Compile(true);
    string scaleSetRequestString = scaleSetRequest.Compile(true);

    OutToConsole(scaleGetRequestString);
    OutToConsole(scaleSetRequestString);

    OutToFile(scaleGetRequestString, "resultsGet.txt");
    OutToFile(scaleSetRequestString, "resultsSet.txt");
}
