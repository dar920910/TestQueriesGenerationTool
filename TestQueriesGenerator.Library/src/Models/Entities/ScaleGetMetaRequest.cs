using TestQueriesGenerator.Library.Models.Abstractions;

namespace TestQueriesGenerator.Library.Models.Entities
{
    public class ScaleGetMetaRequest : ScalableRequest
    {
        List<IdFullGetMetadataRequest> getRequests;
        public ScaleGetMetaRequest(List<IdFullGetMetadataRequest> fullGetRequests)
        {
            getRequests = fullGetRequests;
        }

        public override string Compile(bool isDebugMode)
        {
            string scaleRequest = string.Empty;

            if (isDebugMode)
            {
                foreach (var request in getRequests)
                {
                    scaleRequest += request.Compile(true);
                }
            }
            else
            {
                foreach (var request in getRequests)
                {
                    scaleRequest += request.Compile(false);
                }
            }

            return scaleRequest;
        }
    }
}
