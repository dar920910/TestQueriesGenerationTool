using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Services;

namespace TestQueriesGenerator.Library.Entities
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
