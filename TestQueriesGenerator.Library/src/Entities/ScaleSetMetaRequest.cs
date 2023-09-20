using TestQueriesGenerator.Library.Domains;

namespace TestQueriesGenerator.Library.Entities
{
    public class ScaleSetMetaRequest : ICompilableRequest
    {
        List<IdFullSetMetadataRequest> setRequests;
        public ScaleSetMetaRequest(List<IdFullSetMetadataRequest> fullSetRequests)
        {
            setRequests = fullSetRequests;
        }

        public string Compile(bool isDebugMode)
        {
            string scaleRequest = string.Empty;

            if (isDebugMode)
            {
                foreach (var request in setRequests)
                {
                    scaleRequest += request.Compile(true);
                }
            }
            else
            {
                foreach (var request in setRequests)
                {
                    scaleRequest += request.Compile(false);
                }
            }

            return scaleRequest;
        }
    }
}
