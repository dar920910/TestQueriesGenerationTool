//-----------------------------------------------------------------------
// <copyright file="OutputConsoleDevice.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestQueriesGenerator.Library.Domains;
using static System.Console;

internal static class OutputConsoleDevice
{
    internal static void OutCompiledRequest(string compiledRequestString)
    {
        WriteLine(compiledRequestString);
    }

    internal static void OutAllCompiledRequests(string[] compiledRequestStrings)
    {
        foreach (var request in compiledRequestStrings)
        {
            WriteLine(request);
        }
    }

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

    internal static void OutScaleEntities(List<ScalableEntity> scaleEntities)
    {
        foreach (var scaleEntity in scaleEntities)
        {
            Write("{0}: ", scaleEntity.IdNamePrefix);
            Write("[{0};{1}]", scaleEntity.FirstScalePostfixNumber, scaleEntity.LastScalePostfixNumber);
            WriteLine();
        }
    }

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
}
