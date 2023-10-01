namespace job_scheduler_service.Config
{
    public class FileStorage
    {
        /**
         * @void 
         * @static
         * @public
         * WriteFile
         * 
         * @param
         * - path => Folder path
         * 
         * This function will move file to destinated path with this methodology below:
         * 1. If directory not exist
         *      1.1     Create directory 
         * 2. Write the file to destinated path.
         */
        public static void WriteFile(string path, IFormFile file, string targetFileName)
        {
            string pathTarget = @path;

            // Call off step 1 to 1.1
            if (!Directory.Exists(pathTarget))
            {
                Directory.CreateDirectory(pathTarget);
            }

            // Call off step 2
            Stream fileStream = new FileStream(Path.Combine(pathTarget, targetFileName), FileMode.Create);
            file.CopyTo(fileStream);
            fileStream.Close();
        }
    }
}
