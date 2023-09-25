using etl_job_service.Config;
using etl_job_service.Entity.Job;

namespace etl_job_service.Repository.Job
{
    public class JobRepository : BaseRepository, IJobRepository
    {
        public JobRepository(DatabaseContext context) : base(context){}

        public MapImageProfileJobScheduler Create(string scheduleId, string imageId)
        {
            MapImageProfileJobScheduler scheduler = new MapImageProfileJobScheduler();
            scheduler.imageId = imageId;
            scheduler.scheduleId = scheduleId;

            this._context.MapImageProfileJobScheduler.Add(scheduler);
            this._context.SaveChanges();

            return this.GetDataById(scheduler.id);
        }

        public MapImageProfileJobScheduler GetDataById(string id)
        {
            return this._context.MapImageProfileJobScheduler.FirstOrDefault(e => e.id == id);
        }
    }
}
