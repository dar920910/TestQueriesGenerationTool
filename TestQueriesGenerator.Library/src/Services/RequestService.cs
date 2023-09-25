//-----------------------------------------------------------------------
// <copyright file="RequestService.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Library.Services;

using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Entities;
using static System.Console;

public static class RequestService
{
    public static Dictionary<MetadataSelectionQueryUnit, ScalableEntity> CombineMetadataSelectionQueryScales(List<MetadataSelectionQueryUnit> queryUnits, List<ScalableEntity> scales)
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

    public static Dictionary<MetadataCreationQueryUnit, ScalableEntity> CombineMetadataCreationQueryScales(List<MetadataCreationQueryUnit> queryUnits, List<ScalableEntity> scales)
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

    public static void OutGetScales(Dictionary<MetadataSelectionQueryUnit, ScalableEntity> getScales)
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

    public static void OutSetScales(Dictionary<MetadataCreationQueryUnit, ScalableEntity> setScales)
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

    public static List<MetadataSelectionQueryUnit> CreateGetUnitsList(Dictionary<MetadataSelectionQueryUnit, ScalableEntity> getScales)
    {
        var queryUnits = new List<MetadataSelectionQueryUnit>();

        foreach (var getScale in getScales)
        {
            for (uint idCount = getScale.Value.FirstScalePostfixNumber; idCount <= getScale.Value.LastScalePostfixNumber; idCount++)
            {
                string idName = CreateIdName(getScale.Value.IdNamePrefix, idCount);

                var unit = new MetadataSelectionQueryUnit(idName);
                unit.Mirror(getScale.Key);

                queryUnits.Add(unit);
            }
        }

        return queryUnits;
    }

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

    public static List<MetadataCreationQueryUnit> CreateSetUnitsList(Dictionary<MetadataCreationQueryUnit, ScalableEntity> setScales)
    {
        var queryUnits = new List<MetadataCreationQueryUnit>();

        foreach (var setScale in setScales)
        {
            for (uint idCount = setScale.Value.FirstScalePostfixNumber; idCount <= setScale.Value.LastScalePostfixNumber; idCount++)
            {
                string idName = CreateIdName(setScale.Value.IdNamePrefix, idCount);

                var unit = new MetadataCreationQueryUnit(idName);
                unit.Mirror(setScale.Key);

                queryUnits.Add(unit);
            }
        }

        return queryUnits;
    }

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

    public static void OutScaleEntities(List<ScalableEntity> scaleEntities)
    {
        foreach (var scaleEntity in scaleEntities)
        {
            Write("{0}: ", scaleEntity.IdNamePrefix);
            Write("[{0};{1}]", scaleEntity.FirstScalePostfixNumber, scaleEntity.LastScalePostfixNumber);
            WriteLine();
        }
    }

    public static void OutGetRequests(List<MetadataSelectionQueryUnit> getUnits)
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

    public static void OutSetRequests(List<MetadataCreationQueryUnit> setUnits)
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

    public static void AddAllMetadataFieldsToGetUnit(MetadataSelectionQueryUnit getUnit, ref List<IdGetFieldRequest> getRequests)
    {
        if (getUnit.Agency)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Agency));
        }

        if (getUnit.Department)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Department));
        }

        if (getUnit.Description)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Description));
        }

        if (getUnit.Title)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Title));
        }

        if (getUnit.Type)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Type));
        }

        if (getUnit.UserField1)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.UserField1));
        }

        if (getUnit.UserField2)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.UserField2));
        }

        if (getUnit.UserField3)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.UserField3));
        }

        if (getUnit.UserField4)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.UserField4));
        }

        if (getUnit.RecordTime)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.RecordTime));
        }

        if (getUnit.ModifiedTime)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.ModifiedTime));
        }

        if (getUnit.KillDate)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.KillDate));
        }

        if (getUnit.SOM)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.SOM));
        }

        if (getUnit.DAR)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.DAR));
        }

        if (getUnit.GOP)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.GOP));
        }

        if (getUnit.FileSize)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.FileSize));
        }

        if (getUnit.Resolution)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Resolution));
        }

        if (getUnit.VideoFormat)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.VideoFormat));
        }

        if (getUnit.BitRate)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.BitRate));
        }

        if (getUnit.Handle)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Handle));
        }

        if (getUnit.Link)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Link));
        }

        if (getUnit.MachineName)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.MachineName));
        }

        if (getUnit.UserName)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.UserName));
        }

        if (getUnit.AudioBits)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.AudioBits));
        }

        if (getUnit.AudioChannels)
        {
            getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.AudioChannels));
        }
    }

    public static void AddAllMetadataFieldsToSetUnit(MetadataCreationQueryUnit setUnit, ref List<IdSetFieldRequest> setRequests)
    {
        if (setUnit.Agency != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, MetaAttribute.Agency, setUnit.Agency));
        }

        if (setUnit.Department != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, MetaAttribute.Department, setUnit.Department));
        }

        if (setUnit.Description != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, MetaAttribute.Description, setUnit.Description));
        }

        if (setUnit.Title != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, MetaAttribute.Title, setUnit.Title));
        }

        if (setUnit.Type != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, MetaAttribute.Type, setUnit.Type));
        }

        if (setUnit.UserField1 != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, MetaAttribute.UserField1, setUnit.UserField1));
        }

        if (setUnit.UserField2 != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, MetaAttribute.UserField2, setUnit.UserField2));
        }

        if (setUnit.UserField3 != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, MetaAttribute.UserField3, setUnit.UserField3));
        }

        if (setUnit.UserField4 != null)
        {
            setRequests.Add(new IdSetFieldRequest(setUnit.Name, MetaAttribute.UserField4, setUnit.UserField4));
        }
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
}
