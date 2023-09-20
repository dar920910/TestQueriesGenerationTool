namespace TestQueriesGenerator.Library.Services
{
    public static class ConfigService
    {
        private const string scaleRequestCfgFileName = "request.xml";
        private const string requestGetTypeCfgFileName = "units-get.xml";
        private const string requestSetTypeCfgFileName = "units-set.xml";

        private static string configHomeDirectory;
        public static string ScaleRequestConfigPath { get; }
        public static string RequestGetTypeConfigPath { get; }
        public static string RequestSetTypeConfigPath { get; }

        public static bool IsReady { get; }
        static ConfigService()
        {
            configHomeDirectory = GetConfigHomeDirectory();

            string scaleRequestConfigPath = Path.Combine(configHomeDirectory, scaleRequestCfgFileName);
            string requestGetTypeConfigPath = Path.Combine(configHomeDirectory, requestGetTypeCfgFileName);
            string requestSetTypeConfigPath = Path.Combine(configHomeDirectory, requestSetTypeCfgFileName);

            bool isScaleCfgReady = false;
            bool isRequestGetCfgReady = false;
            bool isRequestSetCfgReady = false;

            if (HasScaleRequestConfig(scaleRequestConfigPath))
            {
                ScaleRequestConfigPath = scaleRequestConfigPath;
                isScaleCfgReady = true;
            }

            if (HasScaleRequestConfig(requestGetTypeConfigPath))
            {
                RequestGetTypeConfigPath = requestGetTypeConfigPath;
                isRequestGetCfgReady = true;
            }

            if (HasScaleRequestConfig(requestSetTypeConfigPath))
            {
                RequestSetTypeConfigPath = requestSetTypeConfigPath;
                isRequestSetCfgReady = true;
            }

            IsReady = ( isScaleCfgReady && isRequestGetCfgReady && isRequestSetCfgReady );
        }

        private static bool HasScaleRequestConfig(string requestConfigPath)
        {
            if (File.Exists(requestConfigPath))
            {
                OutConfigStatusIsSuccess(requestConfigPath);
                return true;
            }
            else
            {
                OutConfigStatusIsFailed(requestConfigPath);
                return false;
            }
        }

        private static string GetConfigHomeDirectory()
        {
            string configHomeDirectory = Directory.GetCurrentDirectory() + @"\~cfg\";

            if (!Directory.Exists(configHomeDirectory))
            {
                Directory.CreateDirectory(configHomeDirectory);
            }

            return configHomeDirectory;
        }

        private static void OutConfigStatusIsSuccess(string configPath)
        {
            Console.WriteLine(" [SUCCESS]: \'{0}\' config file was successfully found.", configPath);
        }

        private static void OutConfigStatusIsFailed(string configPath)
        {
            Console.WriteLine(" [FAILED]: \'{0}\' config file was not detected.", configPath);
        }
    }
}
