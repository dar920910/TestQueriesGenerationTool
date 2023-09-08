using System.Xml.Serialization;
using TestQueriesGenerator.Library.Models.Domains;

using static TestQueriesGenerator.Library.Models.Services.ConfigService;

namespace TestQueriesGenerator.Library.Models.Services
{
    public static class DeserializationService
    {
        public static List<ScalableEntity> DeserializeScalableEntities()
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

        public static List<MediaGetUnit> DeserializeMediaGetUnits()
        {
            var mediaGetUnits = new List<MediaGetUnit>();

            string getPath = RequestGetTypeConfigPath;
            var xsGetUnits = new XmlSerializer(typeof(List<MediaGetUnit>));

            using (FileStream xmlLoad = File.Open(getPath, FileMode.Open))
            {
                mediaGetUnits = (List<MediaGetUnit>)xsGetUnits.Deserialize(xmlLoad);
            }

            return mediaGetUnits;
        }

        public static List<MediaSetUnit> DeserializeMediaSetUnits()
        {
            var mediaSetUnits = new List<MediaSetUnit>();

            string setPath = RequestSetTypeConfigPath;
            var xsSetUnits = new XmlSerializer(typeof(List<MediaSetUnit>));

            using (FileStream xmlLoad = File.Open(setPath, FileMode.Open))
            {
                mediaSetUnits = (List<MediaSetUnit>)xsSetUnits.Deserialize(xmlLoad);
            }

            return mediaSetUnits;
        }
    }
}
