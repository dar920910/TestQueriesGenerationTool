//-----------------------------------------------------------------------
// <copyright file="CompilerService.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Services;

using System.Diagnostics;
using System.Xml.Serialization;
using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Entities;

using static System.Console;

/// <summary>
/// Represents static methods to provide features of queries compilation.
/// </summary>
public static class CompilerService
{
    private const string ScaleRequestCfgFileName = "request.xml";
    private const string RequestGetTypeCfgFileName = "units-get.xml";
    private const string RequestSetTypeCfgFileName = "units-set.xml";
    private const string ResultOutputFileName = "requests.test";

    private static readonly string ConfigHomeDirectory;
    private static readonly string ResultOutputFilePath;

    /// <summary>
    /// Gets the path to the configuration file of scalable requests.
    /// </summary>
    /// <value>The path to configuration file.</value>
    public static string ScaleRequestConfigPath { get; }

    /// <summary>
    /// Gets the path to the configuration file for units of selection queries.
    /// </summary>
    /// <value>The path to configuration file.</value>
    public static string RequestGetTypeConfigPath { get; }

    /// <summary>
    /// Gets the path to the configuration file for units of creation queries.
    /// </summary>
    /// <value>The path to configuration file.</value>
    public static string RequestSetTypeConfigPath { get; }

    public static bool IsReady { get; }

    private static string datetimeCompilationStart;
    private static string datetimeCompilationFinish;
    private static uint actualRequestsCount;
    public static uint expectedRequestsCount;

    static CompilerService()
    {
        ConfigHomeDirectory = Directory.GetCurrentDirectory() + @"\~cfg\";
        if (!Directory.Exists(ConfigHomeDirectory))
        {
            Directory.CreateDirectory(ConfigHomeDirectory);
        }

        string scaleRequestConfigPath = Path.Combine(ConfigHomeDirectory, ScaleRequestCfgFileName);
        string requestGetTypeConfigPath = Path.Combine(ConfigHomeDirectory, RequestGetTypeCfgFileName);
        string requestSetTypeConfigPath = Path.Combine(ConfigHomeDirectory, RequestSetTypeCfgFileName);

        bool isScaleCfgReady = false;
        bool isRequestGetCfgReady = false;
        bool isRequestSetCfgReady = false;

        if (HasScaleRequestConfig(scaleRequestConfigPath))
        {
            ScaleRequestConfigPath = scaleRequestConfigPath;
            isScaleCfgReady = true;
        }

        if (HasScaleRequestConfig(requestGetTypeConfigPath))
        {
            RequestGetTypeConfigPath = requestGetTypeConfigPath;
            isRequestGetCfgReady = true;
        }

        if (HasScaleRequestConfig(requestSetTypeConfigPath))
        {
            RequestSetTypeConfigPath = requestSetTypeConfigPath;
            isRequestSetCfgReady = true;
        }

        IsReady = isScaleCfgReady && isRequestGetCfgReady && isRequestSetCfgReady;

        string outDirectory = Directory.GetCurrentDirectory() + @"\~out\";
        if (!Directory.Exists(outDirectory))
        {
            Directory.CreateDirectory(outDirectory);
        }

        ResultOutputFilePath = Path.Combine(outDirectory, ResultOutputFileName);

        actualRequestsCount = 0;
        expectedRequestsCount = 0;
    }

    /// <summary>
    /// Execute compilation of all valid queries described in configuration files.
    /// </summary>
    public static void Run()
    {
        OutBeforeCompilation();

        if (IsReady)
        {
            var compilationStopwatch = new Stopwatch();

            ProcessCompilationStart(ref compilationStopwatch);

            List<ScalableEntity> scales = RetrieveScalableEntities();

            string compiledScaleGetRequest = CompileScaleGetRequest(scales, true);
            string compiledScaleSetRequest = CompileScaleSetRequest(scales, true);

            string[] compiledRequests = { compiledScaleGetRequest, compiledScaleSetRequest };
            OutToFile(compiledRequests);

            ProcessCompilationFinish(ref compilationStopwatch);
        }
        else
        {
            OutCompilationIsImpossible();
        }
    }

    public static void OutToConsole(string compiledRequestString)
    {
        WriteLine(compiledRequestString);
    }

    public static void OutToConsole(string[] compiledRequestStrings)
    {
        foreach (var request in compiledRequestStrings)
        {
            WriteLine(request);
        }
    }

    public static void OutToFile(string compiledRequest)
    {
        var outputStream = new StreamWriter(ResultOutputFilePath, append: false);
        outputStream.Write(compiledRequest);
        outputStream.Close();
    }

    public static void OutToFile(string[] compiledRequests)
    {
        var outputStream = new StreamWriter(ResultOutputFilePath, append: false);

        foreach (var request in compiledRequests)
        {
            outputStream.Write(request);
        }

        outputStream.Close();
    }

    public static void OutToFile(string compiledRequest, string targetFile)
    {
        try
        {
            var outputStream = new StreamWriter(targetFile, append: false);
            outputStream.Write(compiledRequest);
            outputStream.Close();
        }
        catch (FileNotFoundException exception)
        {
            WriteLine(exception.Message);
        }
    }

    public static void OutToFile(string[] compiledRequests, string targetFile)
    {
        try
        {
            var outputStream = new StreamWriter(targetFile, append: false);

            foreach (var request in compiledRequests)
            {
                outputStream.Write(request);
            }

            outputStream.Close();
        }
        catch (FileNotFoundException exception)
        {
            WriteLine(exception.Message);
        }
    }

    private static bool HasScaleRequestConfig(string requestConfigPath)
    {
        if (File.Exists(requestConfigPath))
        {
            OutConfigStatusIsSuccess(requestConfigPath);
            return true;
        }
        else
        {
            OutConfigStatusIsFailed(requestConfigPath);
            return false;
        }
    }

    private static void OutConfigStatusIsSuccess(string configPath)
    {
        WriteLine(" [SUCCESS]: \'{0}\' config file was successfully found.", configPath);
    }

    private static void OutConfigStatusIsFailed(string configPath)
    {
        WriteLine(" [FAILED]: \'{0}\' config file was not detected.", configPath);
    }

    private static List<ScalableEntity> RetrieveScalableEntities()
    {
        var scaleEntities = new List<ScalableEntity>();

        var xsScales = new XmlSerializer(typeof(List<ScalableEntity>));
        string path = ScaleRequestConfigPath;

        using (FileStream xmlLoad = File.Open(path, FileMode.Open))
        {
            scaleEntities = (List<ScalableEntity>)xsScales.Deserialize(xmlLoad);
        }

        return scaleEntities;
    }

    private static string CompileScaleGetRequest(List<ScalableEntity> scales, bool isDebugMode)
    {
        List<MetadataSelectionQueryUnit> queryUnits = DeserializeMetadataSelectionQueryUnits();
        Dictionary<MetadataSelectionQueryUnit, ScalableEntity> queryScales = RequestService.CombineMetadataSelectionQueryScales(queryUnits, scales);
        List<MetadataSelectionQueryUnit> metadataGetUnits = RequestService.CreateGetUnitsList(queryScales);
        ScaleGetMetaRequest scaleGetRequest = RequestService.CreateScaleGetRequest(metadataGetUnits);

        return scaleGetRequest.Compile(isDebugMode);
    }

    private static List<MetadataSelectionQueryUnit> DeserializeMetadataSelectionQueryUnits()
    {
        var queryUnits = new List<MetadataSelectionQueryUnit>();

        string getPath = RequestGetTypeConfigPath;
        var xsGetUnits = new XmlSerializer(typeof(List<MetadataSelectionQueryUnit>));

        using (FileStream xmlLoad = File.Open(getPath, FileMode.Open))
        {
            queryUnits = (List<MetadataSelectionQueryUnit>)xsGetUnits.Deserialize(xmlLoad);
        }

        return queryUnits;
    }

    private static string CompileScaleSetRequest(List<ScalableEntity> scales, bool isDebugMode)
    {
        List<MetadataCreationQueryUnit> queryUnits = DeserializeMetadataCreationQueryUnits();
        Dictionary<MetadataCreationQueryUnit, ScalableEntity> queryScales = RequestService.CombineMetadataCreationQueryScales(queryUnits, scales);
        List<MetadataCreationQueryUnit> metadataSetUnits = RequestService.CreateSetUnitsList(queryScales);
        ScaleSetMetaRequest scaleSetRequest = RequestService.CreateScaleSetRequest(metadataSetUnits);

        return scaleSetRequest.Compile(isDebugMode);
    }

    private static List<MetadataCreationQueryUnit> DeserializeMetadataCreationQueryUnits()
    {
        var queryUnits = new List<MetadataCreationQueryUnit>();

        string setPath = RequestSetTypeConfigPath;
        var xsSetUnits = new XmlSerializer(typeof(List<MetadataCreationQueryUnit>));

        using (FileStream xmlLoad = File.Open(setPath, FileMode.Open))
        {
            queryUnits = (List<MetadataCreationQueryUnit>)xsSetUnits.Deserialize(xmlLoad);
        }

        return queryUnits;
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
        string sep = " - ";
        string dateSep = ".";
        string timeSep = ".";
        string zero = "0";
        bool ms = true;

        return GetDateAndTime(sep, dateSep, timeSep, ms, zero);
    }

    private static string GetDateAndTime(string sep, string dateSep, string timeSep, bool ms, string zero)
    {
        string datetime, date, time;

        date = GetDate(dateSep, zero);
        time = GetTime(timeSep, ms, zero);

        datetime = date + sep + time;

        return datetime;
    }

    private static string GetDate(string sep, string zero)
    {
        string date, dtYear, dtMonth, dtDay;
        int year, month, day;

        year = DateTime.Now.Year;
        month = DateTime.Now.Month;
        day = DateTime.Now.Day;

        dtYear = GetDateOrTimeWithZero(year, zero);
        dtMonth = GetDateOrTimeWithZero(month, zero);
        dtDay = GetDateOrTimeWithZero(day, zero);

        date = dtYear + sep + dtMonth + sep + dtDay;

        return date;
    }

    private static string GetTime(string sep, bool ms, string zero)
    {
        string time, tmHour, tmMinute, tmSecond;
        int hour, minute, second;

        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        second = DateTime.Now.Second;

        tmHour = GetDateOrTimeWithZero(hour, zero);
        tmMinute = GetDateOrTimeWithZero(minute, zero);
        tmSecond = GetDateOrTimeWithZero(second, zero);

        time = tmHour + sep + tmMinute + sep + tmSecond;

        if (ms)
        {
            int millisecond;
            string tmMillisecond;

            millisecond = DateTime.Now.Millisecond;
            tmMillisecond = GetMillisecondWithZero(millisecond, zero);

            time += sep + tmMillisecond;
        }

        return time;
    }

    private static string GetDateOrTimeWithZero(int datetimeValue, string zero)
    {
        return (datetimeValue < 10) ? zero + datetimeValue.ToString() : datetimeValue.ToString();
    }

    private static string GetMillisecondWithZero(int millisecond, string zero)
    {
        if (millisecond < 10)
        {
            return zero + zero + millisecond.ToString();
        }

        if (millisecond < 100)
        {
            return zero + millisecond.ToString();
        }

        return millisecond.ToString();
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
        char sepSymbol = '-';
        byte sepCount = 150;

        WriteLine("{0}", new string(sepSymbol, sepCount));
    }
}
