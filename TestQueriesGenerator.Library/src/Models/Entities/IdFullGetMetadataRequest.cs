using TestQueriesGenerator.Library.Models.Abstractions;

namespace TestQueriesGenerator.Library.Models.Entities
{
    public class IdFullGetMetadataRequest : FullMetadataRequest
    {
        List<IdGetFieldRequest> getMetadataRequests;
        public IdFullGetMetadataRequest(List<IdGetFieldRequest> idGetFieldRequests)
        {
            getMetadataRequests = idGetFieldRequests;
        }

        public override string Compile(bool isDebugMode)
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
