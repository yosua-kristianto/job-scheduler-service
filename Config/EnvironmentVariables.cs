using System.Collections;

namespace etl_job_service.Config
{
    /**
     * @config
     * @singleton
     * EnvironmentVariables
     * 
     * This class is the helper for extracting selected values from the appsettings file to 
     * serialized value for easier accessibility.
     */ 
    public class EnvironmentVariables
    {
        private static EnvironmentVariables _instance = null;
        private readonly Dictionary<string, string> keys = new();

        private EnvironmentVariables() { }

        public static EnvironmentVariables Instance()
        {
            if( _instance == null)
            {
                _instance = new EnvironmentVariables();
            }
            return _instance;
        }

        public static EnvironmentVariables GetInstance() => _instance;

        /**
         * @public 
         * Key
         * 
         * This function used for retrieving registered value within keys by determined key name.
         */
        public string Key(string key) 
        {
            return this.keys[key];
        }
    }
}
