using TestQueriesGenerator.Library.Models.Abstractions;

namespace TestQueriesGenerator.Library.Models.Entities
{
    public class ScaleSetMetaRequest : NxScalableRequest
    {
        List<IdFullSetMetadataRequest> setRequests;
        public ScaleSetMetaRequest(List<IdFullSetMetadataRequest> fullSetRequests)
        {
            setRequests = fullSetRequests;
        }

        public override string Compile(bool isDebugMode)
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
