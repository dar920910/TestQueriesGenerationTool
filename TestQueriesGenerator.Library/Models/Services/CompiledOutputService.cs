namespace TestQueriesGenerator.Library.Models.Services
{
    public static class CompiledOutputService
    {
        private static readonly string outputPath;

        static CompiledOutputService()
        {
            string outDirectory = GetTargetOutputDirectory();
            string outFileName = GetTargetOutputFileName();

            if (!Directory.Exists(outDirectory))
            {
                Directory.CreateDirectory(outDirectory);
            }

            outputPath = outDirectory + outFileName;
        }

        private static string GetTargetOutputDirectory() => ( Directory.GetCurrentDirectory() + @"\~out\" );
        private static string GetTargetOutputFileName() => "requests.npsrt";

        public static void OutToConsole(string compiledRequestString)
        {
            Console.WriteLine(compiledRequestString);
        }

        public static void OutToConsole(string[] compiledRequestStrings)
        {
            foreach (var request in compiledRequestStrings)
            {
                Console.WriteLine(request);
            }
        }

        public static void OutToFile(string compiledRequest)
        {
            var outputStream = new StreamWriter(outputPath, false);
            outputStream.Write(compiledRequest);
            outputStream.Close();
        }

        public static void OutToFile(string[] compiledRequests)
        {
            var outputStream = new StreamWriter(outputPath, false);

            foreach (var request in compiledRequests)
            {
                outputStream.Write(request);
            }

            outputStream.Close();
        }

        public static void OutToFile(string compiledRequest, string targetFile)
        {
            try
            {
                var outputStream = new StreamWriter(targetFile, false);
                outputStream.Write(compiledRequest);
                outputStream.Close();
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public static void OutToFile(string[] compiledRequests, string targetFile)
        {
            try
            {
                var outputStream = new StreamWriter(targetFile, false);

                foreach (var request in compiledRequests)
                {
                    outputStream.Write(request);
                }

                outputStream.Close();
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
