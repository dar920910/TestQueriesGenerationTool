using TestQueriesGenerator.Library.Models.Abstractions;
using TestQueriesGenerator.Library.Models.Services;

namespace TestQueriesGenerator.Library.Models.Entities
{
    public class IdGetFieldRequest : NxMetadataFieldRequest
    {
        public IdGetFieldRequest(string idName, string metadataField)
        {
            command = "get_field";
            targetID = idName;
            metadataFieldName = metadataField;

            CompilerService.Assign();
        }

        public override string Compile(bool isDebugMode)
        {
            string compiledRequest = command + " " + metadataFieldName + " " + targetID;

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
