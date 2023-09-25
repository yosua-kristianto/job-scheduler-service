using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace etl_job_service.Entity.View
{
    /**
     * OcrResultRecap
     * 
     * @version 0.0.1
     */
    [Table("ocr_view_image_result_recap")]
    public class OcrResultRecap
    {
        [Column("image_original_name")]
        [Key]
        public string imageOriginalName { get; private set; }

        [Column("image_in_server_name")]
        public string imageServerName { get; private set; }

        [Column("result")]
        public string result { get; private set; }

        [Column("cer_point")]
        public decimal cer { get; private set; }

        [Column("report_issued_date")]
        public string report_issued_date { get; private set; }

    }
}
