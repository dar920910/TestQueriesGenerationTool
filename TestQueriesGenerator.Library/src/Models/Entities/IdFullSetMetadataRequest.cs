using TestQueriesGenerator.Library.Models.Domains;

namespace TestQueriesGenerator.Library.Models.Entities
{
    public class IdFullSetMetadataRequest : ICompilableRequest
    {
        List<IdSetFieldRequest> setMetadataRequests;
        public IdFullSetMetadataRequest(List<IdSetFieldRequest> idSetFieldRequests)
        {
            setMetadataRequests = idSetFieldRequests;
        }

        public string Compile(bool isDebugMode)
        {
            string targetRequest = string.Empty;

            if (isDebugMode)
            {
                foreach (var setRequest in setMetadataRequests)
                {
                    targetRequest += setRequest.Compile(true) + "\n";
                }
            }
            else
            {
                foreach (var setRequest in setMetadataRequests)
                {
                    targetRequest += setRequest.Compile(false);
                }
            }

            return  targetRequest;
        }
    }
}
