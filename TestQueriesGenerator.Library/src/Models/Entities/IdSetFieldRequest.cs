using TestQueriesGenerator.Library.Models.Abstractions;
using TestQueriesGenerator.Library.Models.Services;

namespace TestQueriesGenerator.Library.Models.Entities
{
    public class IdSetFieldRequest : MetadataFieldRequest
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

        public override string Compile(bool isDebugMode)
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
