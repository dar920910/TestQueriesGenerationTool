using System.Diagnostics;
using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Entities;

using static System.Console;
using static TestQueriesGenerator.Library.Services.DateTimeService;
using static TestQueriesGenerator.Library.Services.GeneratorService;

namespace TestQueriesGenerator.Library.Services
{
    public static class CompilerService
    {
        private static string datetimeCompilationStart;
        private static string datetimeCompilationFinish;
        private static uint actualRequestsCount;
        public static uint expectedRequestsCount;
        static CompilerService()
        {
            actualRequestsCount = 0;
            expectedRequestsCount = 0;
        }

        public static void Run()
        {
            OutBeforeCompilation();

            if (ConfigService.IsReady)
            {
                var compilationStopwatch = new Stopwatch();

                ProcessCompilationStart(ref compilationStopwatch);

                List<ScalableEntity> scales = RetrieveScalableEntities();

                string compiledScaleGetRequest = CompileScaleGetRequest(scales, true);
                string compiledScaleSetRequest = CompileScaleSetRequest(scales, true);

                string[] compiledRequests = { compiledScaleGetRequest, compiledScaleSetRequest };
                CompiledOutputService.OutToFile(compiledRequests);

                ProcessCompilationFinish(ref compilationStopwatch);
            }
            else
            {
                OutCompilationIsImpossible();
            }
        }

        private static List<ScalableEntity> RetrieveScalableEntities()
        {
            return DeserializationService.DeserializeScalableEntities();
        }

        private static string CompileScaleGetRequest(List<ScalableEntity> scales, bool isDebugMode)
        {
            List<MetadataSelectionQueryUnit> queryUnits = DeserializationService.DeserializeMetadataSelectionQueryUnits();
            Dictionary<MetadataSelectionQueryUnit, ScalableEntity> queryScales = RequestService.CombineMetadataSelectionQueryScales(queryUnits, scales);
            List<MetadataSelectionQueryUnit> metadataGetUnits = RequestService.CreateGetUnitsList(queryScales);
            ScaleGetMetaRequest scaleGetRequest = RequestService.CreateScaleGetRequest(metadataGetUnits);

            return scaleGetRequest.Compile(isDebugMode);
        }

        private static string CompileScaleSetRequest(List<ScalableEntity> scales, bool isDebugMode)
        {
            List<MetadataCreationQueryUnit> queryUnits = DeserializationService.DeserializeMetadataCreationQueryUnits();
            Dictionary<MetadataCreationQueryUnit, ScalableEntity> queryScales = RequestService.CombineMetadataCreationQueryScales(queryUnits, scales);
            List<MetadataCreationQueryUnit> metadataSetUnits = RequestService.CreateSetUnitsList(queryScales);
            ScaleSetMetaRequest scaleSetRequest = RequestService.CreateScaleSetRequest(metadataSetUnits);

            return scaleSetRequest.Compile(isDebugMode);
        }

        public static void Trace(string request)
        {
            Write(" >---> [ {0} ]: \'{1}\'", GetCompilationTime(), request);
            ShowCompilationStatus();
        }

        public static void ShowCompilationStatus()
        {
            WriteLine(" >---> request # {0} from {1} requests", ++actualRequestsCount, expectedRequestsCount);
        }

        public static void Assign()
        {
            expectedRequestsCount++;
        }

        private static string GetCompilationTime()
        {
            return GetDateAndTimeDefaultString();
        }

        private static void ProcessCompilationStart(ref Stopwatch timer)
        {
            datetimeCompilationStart = GetCompilationTime();

            OutSeparator();
            WriteLine();
            WriteLine(" [COMPILATION]: STARTING COMPILATION ...");
            WriteLine();
            OutSeparator();

            timer.Start();
        }

        private static void ProcessCompilationFinish(ref Stopwatch timer)
        {
            timer.Stop();

            datetimeCompilationFinish = GetCompilationTime();

            OutSeparator();
            WriteLine();
            WriteLine(" [COMPILATION]: FINISHING COMPILATION ...");
            WriteLine();
            WriteLine(" [INFO] START DATETIME: {0}", datetimeCompilationStart);
            WriteLine(" [INFO] FINISH DATETIME: {0}", datetimeCompilationFinish);
            WriteLine(" [INFO] COMPILATION DURATION: {0}", timer.Elapsed);
            WriteLine();
            WriteLine(" [RESULT] COMPILED REQUESTS: {0} from {1}", actualRequestsCount, expectedRequestsCount);
            WriteLine();
            OutSeparator();
            WriteLine();
        }

        private static void OutBeforeCompilation()
        {
            WriteLine();
            OutSeparator();
            WriteLine("\n Test Queries Generator\n");
            OutSeparator();
        }

        private static void OutCompilationIsImpossible()
        {
            WriteLine();
            Write(" [FAILED]: CONFIGURATION IS NOT VALID. ");
            WriteLine("COMPILATION IS IMPOSSIBLE.");
            OutSeparator();
            WriteLine();
        }

        private static void OutSeparator()
        {
            WriteLine("{0}", BuildSeparator(150));
        }
    }
}
