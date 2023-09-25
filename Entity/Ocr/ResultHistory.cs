using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace etl_job_service.Entity.Ocr
{
    /**
     * ResultHistory
     * 
     * @version 0.0.1
     */
    [Table("ocr_tbl_result_history")]
    public class ResultHistory
    {
        [Key]
        [Column("result_history_id")]
        public string id { get; private set; }

        [Column("job_id")]
        public string jobId { get; private set; }

        [Column("extracted_text")]
        public string extractedText { get; private set; }

        [Column("cer")]
        public decimal? characterErrorRate { get; private set; }

        [Column("notes")]
        public string? notes { get; set; }

        [Column("created_at")]
        public DateTime createdAt { get; private set; }

        [Column("deleted_at")]
        public DateTime? deletedAt { get; private set; }
    }
}
