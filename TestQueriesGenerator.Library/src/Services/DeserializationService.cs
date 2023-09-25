using System.Xml.Serialization;
using TestQueriesGenerator.Library.Domains;

namespace TestQueriesGenerator.Library.Services
{
    public static class DeserializationService
    {
        public static List<ScalableEntity> DeserializeScalableEntities()
        {
            var scaleEntities = new List<ScalableEntity>();

            var xsScales = new XmlSerializer(typeof(List<ScalableEntity>));
            string path = CompilerService.ScaleRequestConfigPath;

            using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            {
                scaleEntities = (List<ScalableEntity>)xsScales.Deserialize(xmlLoad);
            }

            return scaleEntities;
        }

        public static List<MetadataSelectionQueryUnit> DeserializeMetadataSelectionQueryUnits()
        {
            var queryUnits = new List<MetadataSelectionQueryUnit>();

            string getPath = CompilerService.RequestGetTypeConfigPath;
            var xsGetUnits = new XmlSerializer(typeof(List<MetadataSelectionQueryUnit>));

            using (FileStream xmlLoad = File.Open(getPath, FileMode.Open))
            {
                queryUnits = (List<MetadataSelectionQueryUnit>)xsGetUnits.Deserialize(xmlLoad);
            }

            return queryUnits;
        }

        public static List<MetadataCreationQueryUnit> DeserializeMetadataCreationQueryUnits()
        {
            var queryUnits = new List<MetadataCreationQueryUnit>();

            string setPath = CompilerService.RequestSetTypeConfigPath;
            var xsSetUnits = new XmlSerializer(typeof(List<MetadataCreationQueryUnit>));

            using (FileStream xmlLoad = File.Open(setPath, FileMode.Open))
            {
                queryUnits = (List<MetadataCreationQueryUnit>)xsSetUnits.Deserialize(xmlLoad);
            }

            return queryUnits;
        }
    }
}
