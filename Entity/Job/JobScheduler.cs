using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace etl_job_service.Entity.Job
{
    /**
     * JobScheduler
     * 
     * @version 0.0.1
     */
    [Table("job_tbl_job_scheduler")]
    public class JobScheduler
    {
        /**
         * @var
         * @static
         * IS_SYNCHRONOUS_OPERATION
         *      This constant mark whatever the scheduler is meant to be synchronous operation
         * 
         * IS_PROCESSED
         *      This constant mark whatever the scheduler is successfully run.
         */ 
        public static readonly bool IS_SYNCHRONOUS_OPERATION = true;
        public static readonly bool IS_PROCESSED = true;

        [Key]
        [Column("schedule_id")]
        public string id { get; private set; }

        [Column("schedule_time")]
        public DateTime scheduleTime { get; set; }

        [Column("is_synchronous")]
        public bool synchronousOperation { get; set; }

        [Column("schedule_is_processed")]
        public bool processOperation { get; private set; }

        [Column("created_at")]
        public DateTime createdAt { get; private set; }
    }
}
