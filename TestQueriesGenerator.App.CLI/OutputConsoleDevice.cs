//-----------------------------------------------------------------------
// <copyright file="OutputConsoleDevice.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Entities;
using TestQueriesGenerator.Library.Services;
using static System.Console;

/// <summary>
/// Provides static methods for convenient console output of compiled requests.
/// </summary>
internal static class OutputConsoleDevice
{
    /// <summary>
    /// Outputs a compiled request as a single string.
    /// </summary>
    /// <param name="compiledRequestString">Compiled request string.</param>
    internal static void OutCompiledRequest(string compiledRequestString)
    {
        WriteLine(compiledRequestString);
    }

    /// <summary>
    /// Outputs all compiled requests.
    /// </summary>
    /// <param name="compiledRequestStrings">Array of compiled request strings.</param>
    internal static void OutAllCompiledRequests(string[] compiledRequestStrings)
    {
        foreach (var request in compiledRequestStrings)
        {
            WriteLine(request);
        }
    }

    /// <summary>
    /// Outputs scalable entities for units of metadata selection queries.
    /// </summary>
    /// <param name="getScales">Dictionary of scalable entities for units of metadata selection queries.</param>
    internal static void OutGetScales(Dictionary<MetadataSelectionQueryUnit, ScalableEntity> getScales)
    {
        foreach (var getScale in getScales)
        {
            WriteLine();
            WriteLine("Key: {0} | Value: {1}", getScale.Key, getScale.Value);
            WriteLine("RuntimeID (Key | MetadataSelectionQueryUnit): {0}", getScale.Key.RuntimeID);
            WriteLine("RuntimeID (Value | ScalableEntity): {0}", getScale.Value.RuntimeID);
            WriteLine();
        }
    }

    /// <summary>
    /// Outputs scalable entities for units of metadata creation queries.
    /// </summary>
    /// <param name="setScales">Dictionary of scalable entities for units of metadata creation queries.</param>
    internal static void OutSetScales(Dictionary<MetadataCreationQueryUnit, ScalableEntity> setScales)
    {
        foreach (var setScale in setScales)
        {
            WriteLine();
            WriteLine("Key: {0} | Value: {1}", setScale.Key, setScale.Value);
            WriteLine("RuntimeID (Key | MetadataCreationQueryUnit): {0}", setScale.Key.RuntimeID);
            WriteLine("RuntimeID (Value | ScalableEntity): {0}", setScale.Value.RuntimeID);
            WriteLine();
        }
    }

    /// <summary>
    /// Outputs a list of scalable entities.
    /// </summary>
    /// <param name="scaleEntities">The list of scalable entities.</param>
    internal static void OutScaleEntities(List<ScalableEntity> scaleEntities)
    {
        foreach (var scaleEntity in scaleEntities)
        {
            Write("{0}: ", scaleEntity.IdNamePrefix);
            Write("[{0};{1}]", scaleEntity.FirstScalePostfixNumber, scaleEntity.LastScalePostfixNumber);
            WriteLine();
        }
    }

    /// <summary>
    /// Outputs a list of requests to get values of metadata fields.
    /// </summary>
    /// <param name="getUnits">The list of requests to get values of metadata fields.</param>
    internal static void OutGetRequests(List<MetadataSelectionQueryUnit> getUnits)
    {
        foreach (var getUnit in getUnits)
        {
            WriteLine("\nName: {0}", getUnit.Name);
            WriteLine("{0} = {1}", nameof(getUnit.Agency), getUnit.Agency);
            WriteLine("{0} = {1}", nameof(getUnit.Department), getUnit.Department);
            WriteLine("{0} = {1}", nameof(getUnit.Description), getUnit.Description);
            WriteLine("{0} = {1}", nameof(getUnit.UserField1), getUnit.UserField1);
            WriteLine("{0} = {1}", nameof(getUnit.UserField2), getUnit.UserField2);
            WriteLine("{0} = {1}", nameof(getUnit.UserField3), getUnit.UserField3);
            WriteLine("{0} = {1}", nameof(getUnit.UserField4), getUnit.UserField4);
        }
    }

    /// <summary>
    /// Outputs a list of requests to set values of metadata fields.
    /// </summary>
    /// <param name="setUnits">The list of requests to set values of metadata fields.</param>
    internal static void OutSetRequests(List<MetadataCreationQueryUnit> setUnits)
    {
        foreach (var setUnit in setUnits)
        {
            WriteLine("\nName: {0}", setUnit.Name);
            WriteLine("{0} = {1}", nameof(setUnit.Agency), setUnit.Agency);
            WriteLine("{0} = {1}", nameof(setUnit.Department), setUnit.Department);
            WriteLine("{0} = {1}", nameof(setUnit.Description), setUnit.Description);
            WriteLine("{0} = {1}", nameof(setUnit.UserField1), setUnit.UserField1);
            WriteLine("{0} = {1}", nameof(setUnit.UserField2), setUnit.UserField2);
            WriteLine("{0} = {1}", nameof(setUnit.UserField3), setUnit.UserField3);
            WriteLine("{0} = {1}", nameof(setUnit.UserField4), setUnit.UserField4);
        }
    }

    /// <summary>
    /// Outputs location of paths of configuration files.
    /// </summary>
    internal static void OutConfigurationLocation()
    {
        WriteLine("{0}: {1}", nameof(CompilerService.ScaleRequestConfigPath), CompilerService.ScaleRequestConfigPath);
        WriteLine("{0}: {1}", nameof(CompilerService.RequestGetTypeConfigPath), CompilerService.RequestGetTypeConfigPath);
        WriteLine("{0}: {1}", nameof(CompilerService.RequestSetTypeConfigPath), CompilerService.RequestSetTypeConfigPath);
    }

    /// <summary>
    /// Outputs compiled requests from a scalable entity.
    /// </summary>
    /// <param name="scalableEntity">A scalable entity object.</param>
    internal static void OutScalableRequests(ScalableEntity scalableEntity)
    {
        List<MetadataSelectionQueryUnit> metadataGetUnits = CompilerService.CreateGetUnitsList(scalableEntity);
        List<MetadataCreationQueryUnit> metadataSetUnits = CompilerService.CreateSetUnitsList(scalableEntity);

        ScaleGetMetaRequest scaleGetRequest = CompilerService.CreateScaleGetRequest(metadataGetUnits);
        ScaleSetMetaRequest scaleSetRequest = CompilerService.CreateScaleSetRequest(metadataSetUnits);

        string scaleGetRequestString = scaleGetRequest.Compile(true);
        string scaleSetRequestString = scaleSetRequest.Compile(true);

        OutCompiledRequest(scaleGetRequestString);
        OutCompiledRequest(scaleSetRequestString);

        CompilerService.WriteSingleCompiledRequestToTargetFile(scaleGetRequestString, "resultsGet.txt");
        CompilerService.WriteSingleCompiledRequestToTargetFile(scaleSetRequestString, "resultsSet.txt");
    }
}
