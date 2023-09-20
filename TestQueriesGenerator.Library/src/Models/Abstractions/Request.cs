namespace TestQueriesGenerator.Library.Models.Abstractions
{
    public abstract class Request
    {
        protected string command;
        protected string targetID;

        public abstract string Compile(bool isDebugMode);
    }
}
