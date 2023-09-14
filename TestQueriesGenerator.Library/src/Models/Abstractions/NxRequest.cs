namespace TestQueriesGenerator.Library.Models.Abstractions
{
    public abstract class NxRequest
    {
        protected string command;
        protected string targetID;

        public abstract string Compile(bool isDebugMode);
    }
}
