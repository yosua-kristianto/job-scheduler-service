using etl_job_service.Entity.Img;

namespace etl_job_service.Repository
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
    }
}
