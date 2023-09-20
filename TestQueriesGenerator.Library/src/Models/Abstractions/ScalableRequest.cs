namespace TestQueriesGenerator.Library.Models.Abstractions
{
    public abstract class ScalableRequest
    {
        public abstract string Compile(bool isDebugMode);
    }
}
