using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace etl_job_service.Entity.Job
{
    /**
     * MapImageProfileJobScheduler
     * 
     * @version 0.0.1
     */
    [Table("job_map_image_profile_job_scheduler_mapper")]
    public class MapImageProfileJobScheduler
    {
        [Key]
        [Column("job_id")]
        public string id { get; private set; }

        [Column("schedule_id")]
        public string scheduleId { get; set; }

        [Column("image_id")]
        public string imageId { get; set; }
    }
}
