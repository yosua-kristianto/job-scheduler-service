using etl_job_service.Entity.Job;

namespace etl_job_service.Repository.Job
{
    public interface IJobRepository
    {
        /**
         * GetDataById
         * 
         * This function will return the Job data by provided id.
         */
        public MapImageProfileJobScheduler GetDataById(string id);

        /**
         * Create
         * 
         * This function will create new Job data.
         */
        public MapImageProfileJobScheduler Create(string scheduleId, string imageId);
    }
}
