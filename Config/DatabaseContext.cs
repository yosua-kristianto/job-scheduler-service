using etl_job_service.Entity.Img;
using etl_job_service.Entity.Job;
using etl_job_service.Entity.Ocr;
using etl_job_service.Entity.View;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

/**
 * @link https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio
 */
namespace etl_job_service.Config
{
    /**
     * @config
     * DatabaseContext
     * 
     * This file is used for handshake Entity Framework by giving context to connection pool and actually 
     * registering all models used for this context.
     * 
     * @todo Re-enable all commented out models since they are not mapped yet.
     */ 
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        public DbSet<ImageProfile> ImageProfile { get; set; }
        //public DbSet<JobScheduler> JobScheduler { get; set; }
        //public DbSet<MapImageProfileJobScheduler> MapImageProfileJobScheduler { get; set; }
        //public DbSet<ResultHistory> ResultHistory { get; set; }
        //public DbSet<JobProgress> JobProgress { get; set; } 
        //public DbSet<OcrResultRecap> OcrResultRecap { get; set; }
    }
}
