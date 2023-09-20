using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Entities;

namespace TestQueriesGenerator.Library.Services
{
    public static class MetadataService
    {
        public static string CreateIdName(string prefix, uint number)
        {
            return prefix + "_" + GeneratorService.GetIdNumber(number);
        }

        public static void AddAllMetadataFieldsToGetUnit(MetadataSelectionQueryUnit getUnit, ref List<IdGetFieldRequest> getRequests)
        {
            if (getUnit.Agency) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Agency));
            if (getUnit.Department) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Department));
            if (getUnit.Description) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Description));
            if (getUnit.Title) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Title));
            if (getUnit.Type) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Type));
            if (getUnit.UserField1) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.UserField1));
            if (getUnit.UserField2) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.UserField2));
            if (getUnit.UserField3) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.UserField3));
            if (getUnit.UserField4) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.UserField4));
            if (getUnit.RecordTime) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.RecordTime));
            if (getUnit.ModifiedTime) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.ModifiedTime));
            if (getUnit.KillDate) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.KillDate));
            if (getUnit.SOM) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.SOM));
            if (getUnit.DAR) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.DAR));
            if (getUnit.GOP) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.GOP));
            if (getUnit.FileSize) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.FileSize));
            if (getUnit.Resolution) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Resolution));
            if (getUnit.VideoFormat) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.VideoFormat));
            if (getUnit.BitRate) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.BitRate));
            if (getUnit.Handle) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Handle));
            if (getUnit.Link) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.Link));
            if (getUnit.MachineName) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.MachineName));
            if (getUnit.UserName) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.UserName));
            if (getUnit.AudioBits) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.AudioBits));
            if (getUnit.AudioChannels) getRequests.Add(new IdGetFieldRequest(getUnit.Name, MetaAttribute.AudioChannels));
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
    }
}