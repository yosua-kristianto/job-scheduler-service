﻿using job_scheduler_service.Config;
using job_scheduler_service.Entity.Job;

namespace job_scheduler_service.Repository.Job
{
    public class JobSchedulerRepository : BaseRepository, IJobSchedulerRepository
    {
        public JobSchedulerRepository(DatabaseContext context) : base(context){}

        public JobScheduler Create(DateTime scheduleTime, bool sync)
        {
            JobScheduler jobScheduler = new JobScheduler();
            jobScheduler.scheduleTime = scheduleTime;
            jobScheduler.synchronousOperation = sync;

            this._context.JobScheduler.Add(jobScheduler);
            this._context.SaveChanges();

            return this.GetDataById(jobScheduler.id);
        }

        public JobScheduler GetDataById(string id)
        {
            return this._context.JobScheduler.FirstOrDefault(e => e.id == id);
        }
    }
}
