namespace TestQueriesGenerator.Library.Models.Abstractions
{
    public abstract class FullMetadataRequest
    {
        public abstract string Compile(bool isDebugMode);
    }
}