using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Entities;
using static System.Console;

namespace TestQueriesGenerator.Library.Services
{
    public static class RequestService
    {
        private static bool IsEqualRuntimeIDForScaleGetRequest(MetadataSelectionQueryUnit unit, ScalableEntity scalable)
        {
            return unit.RuntimeID.Equals(scalable.RuntimeID);
        }

        private static bool IsEqualRuntimeIDForScaleSetRequest(MetadataCreationQueryUnit unit, ScalableEntity scalable)
        {
            return unit.RuntimeID.Equals(scalable.RuntimeID);
        }

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
                string idNameForGetUnit = MetadataService.CreateIdName(scale.IdNamePrefix, idCount);

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
                    string idName = MetadataService.CreateIdName(getScale.Value.IdNamePrefix, idCount);

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
                string idNameForSetUnit = MetadataService.CreateIdName(scale.IdNamePrefix, idCount);

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
                    string idName = MetadataService.CreateIdName(setScale.Value.IdNamePrefix, idCount);

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

                MetadataService.AddAllMetadataFieldsToGetUnit(unit, ref getRequests);

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

                MetadataService.AddAllMetadataFieldsToSetUnit(unit, ref setRequests);

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
    }
}
