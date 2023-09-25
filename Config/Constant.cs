namespace etl_job_service.Config
{
    public class EnvironmentVariableConstant
    {
        /**
         * @var environmentVariables
         * @static 
         * @public
         * 
         * This variable contains me paraphrasing or should I say remapping all values from 
         * `appsettings.json` file so it is easier to be used across the project file. 
         * 
         * For example extracting value from  
         * ```
         * builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")
         * ```
         */
        public static Dictionary<string, string> environmentVariables = new Dictionary<string, string>
        {
            { "DefaultFileStoragePath", "default-file-storage-path" }
        };
    }
}
