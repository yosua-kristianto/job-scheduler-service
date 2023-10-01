using job_scheduler_service.Entity.Job;

namespace job_scheduler_service.Repository.Job
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
