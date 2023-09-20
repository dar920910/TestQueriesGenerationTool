using TestQueriesGenerator.Library.Models.Domains;
using TestQueriesGenerator.Library.Models.Services;

namespace TestQueriesGenerator.Library.Models.Entities
{
    public class IdSetFieldRequest : AbstractMetadataFieldRequest, ICompilableRequest
    {
        string value;
        public IdSetFieldRequest(string idName, string metadataField, string metadataValue)
        {
            command = "set_field";
            targetID = idName;
            metadataFieldName = metadataField;
            value = metadataValue;

            CompilerService.Assign();
        }

        public string Compile(bool isDebugMode)
        {
            string compiledRequest = command + " " + metadataFieldName + " " + value + " " + targetID;

            CompilerService.Trace(compiledRequest);

            if (isDebugMode)
            {
                return compiledRequest;
            }
            else
            {
                return (compiledRequest += "&");
            }
        }
    }
}
