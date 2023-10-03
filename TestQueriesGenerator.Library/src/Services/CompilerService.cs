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
    private const string ConfigFolderName = "~cfg";
    private const string OutputFolderName = "~out";
    private const string ScaleRequestCfgFileName = "request.xml";
    private const string RequestGetTypeCfgFileName = "units-get.xml";
    private const string RequestSetTypeCfgFileName = "units-set.xml";
    private const string ResultOutputFileName = "requests.test";

    private static readonly string ConfigDirectoryPath;
    private static readonly string OutputDirectoryPath;
    private static readonly string ResultOutputFilePath;

    private static bool isReadyToCompilation;
    private static string datetimeCompilationStart;
    private static string datetimeCompilationFinish;
    private static uint compiledRequestsCount;

    /// <summary>
    /// Initializes static members of the <see cref="CompilerService"/> class.
    /// </summary>
    static CompilerService()
    {
        string currentDirectory = Directory.GetCurrentDirectory();

        ConfigDirectoryPath = CreateTargetDirectory(currentDirectory, ConfigFolderName);

        string scaleRequestConfigPath = Path.Combine(ConfigDirectoryPath, ScaleRequestCfgFileName);
        string requestGetTypeConfigPath = Path.Combine(ConfigDirectoryPath, RequestGetTypeCfgFileName);
        string requestSetTypeConfigPath = Path.Combine(ConfigDirectoryPath, RequestSetTypeCfgFileName);

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

        isReadyToCompilation = isScaleCfgReady && isRequestGetCfgReady && isRequestSetCfgReady;

        OutputDirectoryPath = CreateTargetDirectory(currentDirectory, OutputFolderName);
        ResultOutputFilePath = Path.Combine(OutputDirectoryPath, ResultOutputFileName);

        compiledRequestsCount = 0;
    }

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

    /// <summary>
    /// Execute compilation of all valid queries described in configuration files.
    /// </summary>
    public static void Run()
    {
        OutBeforeCompilation();

        if (isReadyToCompilation)
        {
            var compilationStopwatch = new Stopwatch();

            ProcessCompilationStart(ref compilationStopwatch);

            List<ScalableEntity> scales = RetrieveScalableEntities();

            string compiledScaleGetRequest = CompileScaleGetRequest(scales, true);
            string compiledScaleSetRequest = CompileScaleSetRequest(scales, true);

            string[] compiledRequests = { compiledScaleGetRequest, compiledScaleSetRequest };
            WriteCompiledRequestsToTargetFile(compiledRequests, ResultOutputFilePath);

            ProcessCompilationFinish(ref compilationStopwatch);
        }
        else
        {
            OutCompilationIsImpossible();
        }
    }

    /// <summary>
    /// Registers request compilation for the compiler service.
    /// </summary>
    /// <param name="request">Request compilation message.</param>
    public static void Register(string request)
    {
        compiledRequestsCount++;

        Write(" >---> [ {0} ]: \'{1}\'", GetCompilationTime(), request);
        WriteLine(" >---> request # {0}", compiledRequestsCount);
    }

    /// <summary>
    /// Writes compiled requests to a specified text file.
    /// </summary>
    /// <param name="compiledRequests">Array of compiled request strings.</param>
    /// <param name="targetFile">Output file name.</param>
    public static void WriteCompiledRequestsToTargetFile(string[] compiledRequests, string targetFile)
    {
        using (StreamWriter outputStream = new (targetFile, append: false))
        {
            try
            {
                foreach (var request in compiledRequests)
                {
                    outputStream.Write(request);
                }
            }
            catch (FileNotFoundException exception)
            {
                WriteLine(exception.Message);
            }
        }
    }

    /// <summary>
    /// Writes a single compiled request to a specified text file.
    /// </summary>
    /// <param name="singleCompiledRequest">A single compiled request string.</param>
    /// <param name="targetFile">Output file name.</param>
    public static void WriteSingleCompiledRequestToTargetFile(string singleCompiledRequest, string targetFile)
    {
        using (StreamWriter outputStream = new (targetFile, append: false))
        {
            try
            {
                outputStream.Write(singleCompiledRequest);
            }
            catch (FileNotFoundException exception)
            {
                WriteLine(exception.Message);
            }
        }
    }

    /// <summary>
    /// Creates requests to get values of metadata fields for a single scalable entity.
    /// </summary>
    /// <param name="scale">User-defined scalable entity.</param>
    /// <returns>The list of query units to get values of metadata fields.</returns>
    public static List<MetadataSelectionQueryUnit> CreateGetUnitsList(ScalableEntity scale)
    {
        var queryUnits = new List<MetadataSelectionQueryUnit>();

        for (uint idCount = scale.FirstScalePostfixNumber; idCount <= scale.LastScalePostfixNumber; idCount++)
        {
            string idNameForGetUnit = CreateIdName(scale.IdNamePrefix, idCount);

            var unit = new MetadataSelectionQueryUnit(idNameForGetUnit);

            // Fill all fields' values for 'unit'.
            queryUnits.Add(unit);
        }

        return queryUnits;
    }

    /// <summary>
    /// Creates a list of requests to get values of metadata fields for many scalable entities.
    /// </summary>
    /// <param name="getScales">User-defined dictionary of query units with its scalable entities.</param>
    /// <returns>The list of query units to get values of metadata fields.</returns>
    public static List<MetadataSelectionQueryUnit> CreateGetUnitsList(Dictionary<MetadataSelectionQueryUnit, ScalableEntity> getScales)
    {
        var queryUnits = new List<MetadataSelectionQueryUnit>();

        foreach (var getScale in getScales)
        {
            for (uint idCount = getScale.Value.FirstScalePostfixNumber; idCount <= getScale.Value.LastScalePostfixNumber; idCount++)
            {
                string idName = CreateIdName(getScale.Value.IdNamePrefix, idCount);
                MetadataSelectionQueryUnit unit = new (idName, getScale.Key);
                queryUnits.Add(unit);
            }
        }

        return queryUnits;
    }

    /// <summary>
    /// Creates requests to set values of metadata fields for a single scalable entity.
    /// </summary>
    /// <param name="scale">User-defined scalable entity.</param>
    /// <returns>The list of query units to set values of metadata fields.</returns>
    public static List<MetadataCreationQueryUnit> CreateSetUnitsList(ScalableEntity scale)
    {
        var queryUnits = new List<MetadataCreationQueryUnit>();

        for (uint idCount = scale.FirstScalePostfixNumber; idCount <= scale.LastScalePostfixNumber; idCount++)
        {
            string idNameForSetUnit = CreateIdName(scale.IdNamePrefix, idCount);

            var unit = new MetadataCreationQueryUnit(idNameForSetUnit);

            // Fill all fields' values for 'unit'.
            queryUnits.Add(unit);
        }

        return queryUnits;
    }

    /// <summary>
    /// Creates a list of requests to set values of metadata fields for many scalable entities.
    /// </summary>
    /// <param name="setScales">User-defined dictionary of query units with its scalable entities.</param>
    /// <returns>The list of query units to set values of metadata fields.</returns>
    public static List<MetadataCreationQueryUnit> CreateSetUnitsList(Dictionary<MetadataCreationQueryUnit, ScalableEntity> setScales)
    {
        var queryUnits = new List<MetadataCreationQueryUnit>();

        foreach (var setScale in setScales)
        {
            for (uint idCount = setScale.Value.FirstScalePostfixNumber; idCount <= setScale.Value.LastScalePostfixNumber; idCount++)
            {
                string idName = CreateIdName(setScale.Value.IdNamePrefix, idCount);
                MetadataCreationQueryUnit unit = new (idName, setScale.Key);
                queryUnits.Add(unit);
            }
        }

        return queryUnits;
    }

    /// <summary>
    /// Creates a scalable request to get values of metadata fields for many query units.
    /// </summary>
    /// <param name="queryUnits">User-defined list of query units.</param>
    /// <returns>Scalable request to get values of metadata fields.</returns>
    public static ScaleGetMetaRequest CreateScaleGetRequest(List<MetadataSelectionQueryUnit> queryUnits)
    {
        var fullGetRequests = new List<IdFullGetMetadataRequest>();

        foreach (var unit in queryUnits)
        {
            var getRequests = new List<IdGetFieldRequest>();

            AddAllMetadataFieldsToGetUnit(unit, ref getRequests);

            var fullGetRequest = new IdFullGetMetadataRequest(getRequests);

            fullGetRequests.Add(fullGetRequest);
        }

        return new ScaleGetMetaRequest(fullGetRequests);
    }

    /// <summary>
    /// Creates a scalable request to set values of metadata fields for many query units.
    /// </summary>
    /// <param name="queryUnits">User-defined list of query units.</param>
    /// <returns>Scalable request to set values of metadata fields.</returns>
    public static ScaleSetMetaRequest CreateScaleSetRequest(List<MetadataCreationQueryUnit> queryUnits)
    {
        var fullSetRequests = new List<IdFullSetMetadataRequest>();

        foreach (var unit in queryUnits)
        {
            var setRequests = new List<IdSetFieldRequest>();

            AddAllMetadataFieldsToSetUnit(unit, ref setRequests);

            var fullSetRequest = new IdFullSetMetadataRequest(setRequests);

            fullSetRequests.Add(fullSetRequest);
        }

        return new ScaleSetMetaRequest(fullSetRequests);
    }

    /// <summary>
    /// Creates identifier's name by its prefix and number.
    /// </summary>
    /// <param name="prefix">User-defined prefix.</param>
    /// <param name="number">User-defined number.</param>
    /// <returns>The string name of a identifier.</returns>
    public static string CreateIdName(string prefix, uint number)
    {
        string targetNumber = default;

        uint valueLevel_1 = 1_000_000;
        uint valueLevel_2 = 100_000;
        uint valueLevel_3 = 10_000;
        uint valueLevel_4 = 1_000;
        uint valueLevel_5 = 100;
        uint valueLevel_6 = 10;

        if (number < valueLevel_6)
        {
            targetNumber = AddZeroes(6);
        }
        else if (number < valueLevel_5)
        {
            targetNumber = AddZeroes(5);
        }
        else if (number < valueLevel_4)
        {
            targetNumber = AddZeroes(4);
        }
        else if (number < valueLevel_3)
        {
            targetNumber = AddZeroes(3);
        }
        else if (number < valueLevel_2)
        {
            targetNumber = AddZeroes(2);
        }
        else if (number < valueLevel_1)
        {
            targetNumber = AddZeroes(1);
        }
        else
        {
            targetNumber = string.Empty;
        }

        return prefix + "_" + targetNumber + number.ToString();
    }

    private static string CreateTargetDirectory(string appHomeDirectory, string targetFolder)
    {
        string targetDirectory = Path.Combine(appHomeDirectory, targetFolder);

        if (Directory.Exists(targetDirectory) is false)
        {
            Directory.CreateDirectory(targetDirectory);
        }

        return targetDirectory;
    }

    private static void AddAllMetadataFieldsToGetUnit(MetadataSelectionQueryUnit getUnit, ref List<IdGetFieldRequest> getRequests)
    {
        if (getUnit.Agency)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.Agency));
        }

        if (getUnit.Department)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.Department));
        }

        if (getUnit.Description)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.Description));
        }

        if (getUnit.Title)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.Title));
        }

        if (getUnit.Type)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.Type));
        }

        if (getUnit.UserField1)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.UserField1));
        }

        if (getUnit.UserField2)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.UserField2));
        }

        if (getUnit.UserField3)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.UserField3));
        }

        if (getUnit.UserField4)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.UserField4));
        }

        if (getUnit.RecordTime)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.RecordTime));
        }

        if (getUnit.ModifiedTime)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.ModifiedTime));
        }

        if (getUnit.KillDate)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.KillDate));
        }

        if (getUnit.SOM)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.SOM));
        }

        if (getUnit.DAR)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.DAR));
        }

        if (getUnit.GOP)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.GOP));
        }

        if (getUnit.FileSize)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.FileSize));
        }

        if (getUnit.Resolution)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.Resolution));
        }

        if (getUnit.VideoFormat)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.VideoFormat));
        }

        if (getUnit.BitRate)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.BitRate));
        }

        if (getUnit.Handle)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.Handle));
        }

        if (getUnit.Link)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.Link));
        }

        if (getUnit.MachineName)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.MachineName));
        }

        if (getUnit.UserName)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.UserName));
        }

        if (getUnit.AudioBits)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.AudioBits));
        }

        if (getUnit.AudioChannels)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, Metadata.AudioChannels));
        }
    }

    private static void AddAllMetadataFieldsToSetUnit(MetadataCreationQueryUnit setUnit, ref List<IdSetFieldRequest> setRequests)
    {
        if (setUnit.Agency != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, Metadata.Agency, setUnit.Agency));
        }

        if (setUnit.Department != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, Metadata.Department, setUnit.Department));
        }

        if (setUnit.Description != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, Metadata.Description, setUnit.Description));
        }

        if (setUnit.Title != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, Metadata.Title, setUnit.Title));
        }

        if (setUnit.Type != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, Metadata.Type, setUnit.Type));
        }

        if (setUnit.UserField1 != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, Metadata.UserField1, setUnit.UserField1));
        }

        if (setUnit.UserField2 != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, Metadata.UserField2, setUnit.UserField2));
        }

        if (setUnit.UserField3 != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, Metadata.UserField3, setUnit.UserField3));
        }

        if (setUnit.UserField4 != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, Metadata.UserField4, setUnit.UserField4));
        }
    }

    private static Dictionary<MetadataSelectionQueryUnit, ScalableEntity> CombineMetadataSelectionQueryScales(
        List<MetadataSelectionQueryUnit> queryUnits, List<ScalableEntity> scales)
    {
        var queryScales = new Dictionary<MetadataSelectionQueryUnit, ScalableEntity>();

        foreach (var getUnit in queryUnits)
        {
            foreach (var scale in scales)
            {
                if (IsEqualRuntimeIDForScaleGetRequest(getUnit, scale))
                {
                    queryScales.Add(getUnit, scale);
                }
            }
        }

        return queryScales;
    }

    private static Dictionary<MetadataCreationQueryUnit, ScalableEntity> CombineMetadataCreationQueryScales(
        List<MetadataCreationQueryUnit> queryUnits, List<ScalableEntity> scales)
    {
        var queryScales = new Dictionary<MetadataCreationQueryUnit, ScalableEntity>();

        foreach (var setUnit in queryUnits)
        {
            foreach (var scale in scales)
            {
                if (IsEqualRuntimeIDForScaleSetRequest(setUnit, scale))
                {
                    queryScales.Add(setUnit, scale);
                }
            }
        }

        return queryScales;
    }

    private static bool IsEqualRuntimeIDForScaleGetRequest(MetadataSelectionQueryUnit unit, ScalableEntity scalable)
    {
        return unit.RuntimeID.Equals(scalable.RuntimeID);
    }

    private static bool IsEqualRuntimeIDForScaleSetRequest(MetadataCreationQueryUnit unit, ScalableEntity scalable)
    {
        return unit.RuntimeID.Equals(scalable.RuntimeID);
    }

    private static string AddZeroes(int countZeroes)
    {
        const char zero = '0';
        string zeroString = string.Empty;

        for (int i = 0; i < countZeroes; i++)
        {
            zeroString += zero;
        }

        return zeroString;
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
        Dictionary<MetadataSelectionQueryUnit, ScalableEntity> queryScales = CombineMetadataSelectionQueryScales(queryUnits, scales);
        List<MetadataSelectionQueryUnit> metadataGetUnits = CreateGetUnitsList(queryScales);
        ScaleGetMetaRequest scaleGetRequest = CreateScaleGetRequest(metadataGetUnits);

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
        Dictionary<MetadataCreationQueryUnit, ScalableEntity> queryScales = CombineMetadataCreationQueryScales(queryUnits, scales);
        List<MetadataCreationQueryUnit> metadataSetUnits = CreateSetUnitsList(queryScales);
        ScaleSetMetaRequest scaleSetRequest = CreateScaleSetRequest(metadataSetUnits);

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
        WriteLine(" [RESULT] COMPILED REQUESTS: {0}", compiledRequestsCount);
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
