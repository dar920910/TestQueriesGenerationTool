using TestQueriesGenerator.Library.Models.Domains;
using TestQueriesGenerator.Library.Models.Services;

namespace TestQueriesGenerator.Library.Models.Entities
{
    public class IdGetFieldRequest : AbstractMetadataFieldRequest, ICompilableRequest
    {
        public IdGetFieldRequest(string idName, string metadataField)
        {
            command = "get_field";
            targetID = idName;
            metadataFieldName = metadataField;

            CompilerService.Assign();
        }

        public string Compile(bool isDebugMode)
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
