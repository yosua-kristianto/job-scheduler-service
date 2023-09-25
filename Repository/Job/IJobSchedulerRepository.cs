using etl_job_service.Entity.Job;

namespace etl_job_service.Repository.Job
{
    public interface IJobSchedulerRepository
    {
        /**
         * GetDataById
         * 
         * This function will return the JobScheduler data by provided id.
         */
        public JobScheduler GetDataById(string id);

        /**
         * Create
         * 
         * This function will create new JobSchedule data.
         */
        public JobScheduler Create(DateTime scheduleTime, bool sync);
    }
}
