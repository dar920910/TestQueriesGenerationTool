using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Entities;
using static System.Console;

namespace TestQueriesGenerator.Library.Services
{
    public static class RequestService
    {
        private static bool IsEqualRuntimeIDForScaleGetRequest(MediaGetUnit mediaGetUnit, ScalableEntity scalable)
        {
            return mediaGetUnit.RuntimeID.Equals(scalable.RuntimeID);
        }

        private static bool IsEqualRuntimeIDForScaleSetRequest(MediaSetUnit mediaSetUnit, ScalableEntity scalable)
        {
            return mediaSetUnit.RuntimeID.Equals(scalable.RuntimeID);
        }

        public static Dictionary<MediaGetUnit, ScalableEntity> CombineMediaGetScales(List<MediaGetUnit> getUnits, List<ScalableEntity> scales)
        {
            var mediaGetScales = new Dictionary<MediaGetUnit, ScalableEntity>();

            foreach (var getUnit in getUnits)
            {
                foreach (var scale in scales)
                {
                    if (IsEqualRuntimeIDForScaleGetRequest(getUnit, scale))
                    {
                        mediaGetScales.Add(getUnit, scale);
                    }
                }
            }

            return mediaGetScales;
        }

        public static Dictionary<MediaSetUnit, ScalableEntity> CombineMediaSetScales(List<MediaSetUnit> setUnits, List<ScalableEntity> scales)
        {
            var mediaSetScales = new Dictionary<MediaSetUnit, ScalableEntity>();

            foreach (var setUnit in setUnits)
            {
                foreach (var scale in scales)
                {
                    if (IsEqualRuntimeIDForScaleSetRequest(setUnit, scale))
                    {
                        mediaSetScales.Add(setUnit, scale);
                    }
                }
            }

            return mediaSetScales;
        }

        public static void OutGetScales(Dictionary<MediaGetUnit, ScalableEntity> getScales)
        {
            foreach (var getScale in getScales)
            {
                WriteLine();
                WriteLine("Key: {0} | Value: {1}", getScale.Key, getScale.Value);
                WriteLine("RuntimeID (Key | MediaGetUnit): {0}", getScale.Key.RuntimeID);
                WriteLine("RuntimeID (Value | ScalableEntity): {0}", getScale.Value.RuntimeID);
                WriteLine();
            }
        }

        public static void OutSetScales(Dictionary<MediaSetUnit, ScalableEntity> setScales)
        {
            foreach (var setScale in setScales)
            {
                WriteLine();
                WriteLine("Key: {0} | Value: {1}", setScale.Key, setScale.Value);
                WriteLine("RuntimeID (Key | MediaSetUnit): {0}", setScale.Key.RuntimeID);
                WriteLine("RuntimeID (Value | ScalableEntity): {0}", setScale.Value.RuntimeID);
                WriteLine();
            }
        }

        public static List<MediaGetUnit> CreateGetUnitsList(ScalableEntity scale)
        {
            var mediaGetUnits = new List<MediaGetUnit>();

            for (uint idCount = scale.FirstScalePostfixNumber; idCount <= scale.LastScalePostfixNumber; idCount++)
            {
                string idNameForGetUnit = MetadataService.CreateIdName(scale.IdNamePrefix, idCount);

                var mediaGetUnit = new MediaGetUnit(idNameForGetUnit);

                // TODO: Fill all fields' values for mediaGetUnit.

                mediaGetUnits.Add(mediaGetUnit);
            }

            return mediaGetUnits;
        }

        public static List<MediaGetUnit> CreateGetUnitsList(Dictionary<MediaGetUnit, ScalableEntity> getScales)
        {
            var mediaGetUnits = new List<MediaGetUnit>();

            foreach (var getScale in getScales)
            {
                for (uint idCount = getScale.Value.FirstScalePostfixNumber; idCount <= getScale.Value.LastScalePostfixNumber; idCount++)
                {
                    string idName = MetadataService.CreateIdName(getScale.Value.IdNamePrefix, idCount);

                    var mediaGetUnit = new MediaGetUnit(idName);
                    mediaGetUnit.Mirror(getScale.Key);

                    mediaGetUnits.Add(mediaGetUnit);
                }
            }

            return mediaGetUnits;
        }

        public static List<MediaSetUnit> CreateSetUnitsList(ScalableEntity scale)
        {
           var mediaSetUnits = new List<MediaSetUnit>();

            for (uint idCount = scale.FirstScalePostfixNumber; idCount <= scale.LastScalePostfixNumber; idCount++)
            {
                string idNameForSetUnit = MetadataService.CreateIdName(scale.IdNamePrefix, idCount);

                var mediaSetUnit = new MediaSetUnit(idNameForSetUnit);

                // TODO: Fill all fields' values for mediaSetUnit.

                mediaSetUnits.Add(mediaSetUnit);
            }

            return mediaSetUnits;
        }

        public static List<MediaSetUnit> CreateSetUnitsList(Dictionary<MediaSetUnit, ScalableEntity> setScales)
        {
            var mediaSetUnits = new List<MediaSetUnit>();

            foreach (var setScale in setScales)
            {
                for (uint idCount = setScale.Value.FirstScalePostfixNumber; idCount <= setScale.Value.LastScalePostfixNumber; idCount++)
                {
                    string idName = MetadataService.CreateIdName(setScale.Value.IdNamePrefix, idCount);

                    var mediaSetUnit = new MediaSetUnit(idName);
                    mediaSetUnit.Mirror(setScale.Key);

                    mediaSetUnits.Add(mediaSetUnit);
                }
            }

            return mediaSetUnits;
        }

        public static ScaleGetMetaRequest CreateScaleGetRequest(List<MediaGetUnit> mediaGetUnits)
        {
            var fullGetRequests = new List<IdFullGetMetadataRequest>();

            foreach (var mediaGetUnit in mediaGetUnits)
            {
                var getRequests = new List<IdGetFieldRequest>();

                MetadataService.AddAllMetadataFieldsToGetUnit(mediaGetUnit, ref getRequests);

                var fullGetRequest = new IdFullGetMetadataRequest(getRequests);

                fullGetRequests.Add(fullGetRequest);
            }

            return new ScaleGetMetaRequest(fullGetRequests);
        }

        public static ScaleSetMetaRequest CreateScaleSetRequest(List<MediaSetUnit> mediaSetUnits)
        {
            var fullSetRequests = new List<IdFullSetMetadataRequest>();

            foreach (var mediaSetUnit in mediaSetUnits)
            {
                var setRequests = new List<IdSetFieldRequest>();

                MetadataService.AddAllMetadataFieldsToSetUnit(mediaSetUnit, ref setRequests);

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

        public static void OutGetRequests(List<MediaGetUnit> getUnits)
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

        public static void OutSetRequests(List<MediaSetUnit> setUnits)
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
