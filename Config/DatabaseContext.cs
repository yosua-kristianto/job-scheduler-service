using job_scheduler_service.Entity.Img;
using job_scheduler_service.Entity.Job;
using job_scheduler_service.Entity.Ocr;
using job_scheduler_service.Entity.View;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

/**
 * @link https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio
 */
namespace job_scheduler_service.Config
{
    /**
     * @config
     * DatabaseContext
     * 
     * This file is used for handshake Entity Framework by giving context to connection pool and actually 
     * registering all models used for this context.
     */ 
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        public DbSet<ImageProfile> ImageProfile { get; set; }
        public DbSet<JobScheduler> JobScheduler { get; set; }
        public DbSet<MapImageProfileJobScheduler> MapImageProfileJobScheduler { get; set; }
        public DbSet<ResultHistory> ResultHistory { get; set; }
        public DbSet<JobProgress> JobProgress { get; set; }
        public DbSet<OcrResultRecap> OcrResultRecap { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageProfile>(entity =>
            {
                entity.Property(e => e.id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.createdAt)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<JobScheduler>(entity =>
            {
                entity.Property(e => e.id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.createdAt)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<MapImageProfileJobScheduler>(entity =>
            {
                entity.Property(e => e.id)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ResultHistory>(entity =>
            {
                entity.Property(e => e.id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.createdAt)
                    .ValueGeneratedOnAdd();
            });
        }
    }
}
