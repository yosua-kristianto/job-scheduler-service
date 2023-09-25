using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace etl_job_service.Entity.View
{
    /**
     * JobProgress
     * 
     * @version 0.0.1
     */
    [Table("job_view_get_progress_by_job")]
    public class JobProgress
    {
        [Column("job_id")]
        [Key]
        public string jobId { get; private set; }

        [Column("schedule_id")]
        public string scheduleId { get; private set; }

        [Column("image_original_name")]
        public string imageOriginalName { get; private set; }

        [Column("process_done")]
        public string processDoneFlag { get; private set; }

        [Column("result")]
        public string result { get; private set; }

        [Column("cer")]
        public decimal cer { get; private set; }
    }
}
