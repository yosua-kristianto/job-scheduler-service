using job_scheduler_service.Entity.Img;

namespace job_scheduler_service.Repository.Img
{
    /**
     * @repository
     * ImageProfileRepository
     * 
     * This class contains every query needed within ImageProfile
     */
    public interface IImageProfileRepository
    {
        /**
         * @public 
         * GetAll
         * 
         * This function will return all data from ImageProfile table.
         */
        public List<ImageProfile> GetAll();

        /**
         * @public
         * Create
         * 
         * This function will create a new ImageProfile data for the case of no expectedOutput
         */ 
        public ImageProfile Create(string originalName, string inServerName);

        /**
         * @public
         * Create
         * 
         * This function will create a new ImageProfile data.
         */
        public ImageProfile Create(string originalName, string inServerName, string expectedOutput);

        /**
         * @public
         * GetDataById
         * 
         * This function will return a data of ImageProfile by providing its id.
         */ 
        public ImageProfile GetDataById(string id);
    }
}
