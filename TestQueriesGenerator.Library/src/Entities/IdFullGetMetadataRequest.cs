using TestQueriesGenerator.Library.Domains;

namespace TestQueriesGenerator.Library.Entities
{
    public class IdFullGetMetadataRequest : ICompilableRequest
    {
        List<IdGetFieldRequest> getMetadataRequests;
        public IdFullGetMetadataRequest(List<IdGetFieldRequest> idGetFieldRequests)
        {
            getMetadataRequests = idGetFieldRequests;
        }

        public string Compile(bool isDebugMode)
        {
            string targetRequest = string.Empty;

            if (isDebugMode)
            {
                foreach (var getRequest in getMetadataRequests)
                {
                    targetRequest += getRequest.Compile(true) + "\n";
                }
            }
            else
            {
                foreach (var getRequest in getMetadataRequests)
                {
                    targetRequest += getRequest.Compile(false);
                }
            }

            return  targetRequest;
        }
    }
}
