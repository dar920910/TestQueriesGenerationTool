using TestQueriesGenerator.Library.Models.Abstractions;

namespace TestQueriesGenerator.Library.Models.Entities
{
    public class IdFullSetMetadataRequest : FullMetadataRequest
    {
        List<IdSetFieldRequest> setMetadataRequests;
        public IdFullSetMetadataRequest(List<IdSetFieldRequest> idSetFieldRequests)
        {
            setMetadataRequests = idSetFieldRequests;
        }

        public override string Compile(bool isDebugMode)
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
